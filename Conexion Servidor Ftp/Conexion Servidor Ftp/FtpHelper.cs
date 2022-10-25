using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


/****************************************************************************/
/********                                                            ********/
/********                         FTPHELPER                          ********/
/********                                                            ********/
/****************************************************************************/

namespace Conexion_Servidor_Ftp
{
    public class FtpHelper
    {

        public readonly FtpSettings Settings;
        public static List<string> archivos_ftp = new List<string>();

        public FtpHelper(FtpSettings settings)
        {
            this.Settings = settings;
        }

        public FtpWebRequest CreateRequest(string remotePath)
        {
            var builder = new UriBuilder();
            builder.Scheme = "ftp";
            builder.Port = this.Settings.Port;
            builder.Host = this.Settings.Server;
            if (!string.IsNullOrEmpty(remotePath))
            {
                builder.Path = remotePath;
            }
            var request = (FtpWebRequest)FtpWebRequest.Create(builder.Uri);
            if (!string.IsNullOrEmpty(this.Settings.User) && !string.IsNullOrEmpty(this.Settings.Password))
            {
                request.Credentials = new NetworkCredential(this.Settings.User, this.Settings.Password);
            }
            request.KeepAlive = true;
            return request;
        }

        /// <summary>
        ///MÉTODO QUE OBTIENE LOS FICHEROS DE LA CARPETA DEL FTP
        /// </summary>        
        public List<FtpFile> GetRemoteFiles()
        {
            var ftpClient = CreateRequest(this.Settings.RemoteFolderPath);
            ftpClient.Method = WebRequestMethods.Ftp.ListDirectory;
            var files = new List<FtpFile>();
            using (var response = (FtpWebResponse)ftpClient.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                while (reader.Peek() >= 0)
                {
                    string fileName = reader.ReadLine();
                    if (fileName.Substring(0, 9) != "pedidos/.")
                    {
                        if (fileName.Substring(0, 10) != "pedidos/..")
                        {
                            if (fileName.Substring(0, 11) != "pedidos/old")
                            {
                                files.Add(new FtpFile
                                {
                                    FileName = fileName.Remove(0, 14)
                                });
                            }
                        }
                    }
                }
                return files;
            }

        }

        public void WriteFiles(List<FtpFile> lista, string ruta_fichero)
        {
            StreamWriter writer = null;
            Validaciones validaciones = new Validaciones();
            foreach (var f in lista)
            {
                var ftpClient = CreateRequest(GetRemoteFilePath(f.FileName));
                ftpClient.Method = WebRequestMethods.Ftp.DownloadFile;
                using (var response = (FtpWebResponse)ftpClient.GetResponse())
                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    validaciones.comprobar_fichero_duplicado(ruta_fichero, f.FileName);

                    writer = new StreamWriter(ruta_fichero + "//" + f.FileName);
                    writer.Write(reader.ReadToEnd());
                }
                writer.Close();

            }
        }

        /// <summary>
        ///MÉTODO QUE UTILIZAMOS PARA PASAR LOS FICHEROS DESCARGADOS A LOCAL A UNA CARPETA BACKUP EN FTP
        /// </summary>  
        public void WriteFilesBackupFtp(List<FtpFile> lista)
        {
            foreach (var f in lista)
            {
                var ftpClient = CreateRequest(GetRemoteFilePath(f.FileName));
                /* When in doubt, use these options */
                ftpClient.UseBinary = true;
                ftpClient.UsePassive = true;
                ftpClient.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpClient.Method = WebRequestMethods.Ftp.Rename;
                /* Rename the File */
                ftpClient.RenameTo = "/pedidos/old/" + f.FileName;
                /* Establish Return Communication with the FTP Server */
                var response = (FtpWebResponse)ftpClient.GetResponse();
                /* Resource Cleanup */
                response.Close();
                ftpClient = null;
            }
        }

        /// <summary>
        ///MÉTODO QUE LA RUTA FTP
        /// </summary>   
        public string GetRemoteFilePath(string fileName)
        {
            if (string.IsNullOrEmpty(this.Settings.RemoteFolderPath))
            {
                return "/" + fileName;
            }
            else
            {
                return this.Settings.RemoteFolderPath.TrimEnd('/') + "/" + fileName;
            }
        }

        /// <summary>
        ///MÉTODO PARA LISTAR TODOS LOS FICHEROS DE LA CARPETA FTP
        /// </summary>  
        public List<string> ListDirectory()
        {
            var ftpClient = CreateRequest(this.Settings.RemoteFolderPath);
            ftpClient.Method = WebRequestMethods.Ftp.ListDirectory;
            using (var response = (FtpWebResponse)ftpClient.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                for (int i = 0; i <= archivos_ftp.Count; i++)
                {
                    archivos_ftp.Add(reader.ReadLine());
                    i++;
                }
            }
            return archivos_ftp;
        }
    }
}
