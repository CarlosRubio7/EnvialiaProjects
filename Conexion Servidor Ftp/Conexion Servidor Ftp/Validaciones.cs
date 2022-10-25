using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_Servidor_Ftp
{
    class Validaciones
    {
        
        public bool comprobar_fichero_duplicado(string folderPath, string file)
        {
            bool duplicado = true;
            string File = file;

            if(Directory.EnumerateFiles( folderPath).Count() == 0)
            {
                duplicado = false;
            }

            foreach (string f in Directory.EnumerateFiles(folderPath))
            {
                if(file.Remove(0,7).Substring(0,6) == f.Remove(0,23).Substring(0,6))
                {
                    if (long.Parse(file.Remove(0, 14).Substring(0, 14)) >= long.Parse(f.Remove(0, 30).Substring(0, 14)))
                    {
                        duplicado = true;
                        System.IO.File.Delete(f);
                        break;

                    }
                }
            }
            return duplicado;
        }

        public bool comprobar_tamaño_campos(LineaPedido l)
        {
            bool limite = true;

            if (l.NumeroPedido.Length > 10)
                limite = false;
            else if (l.ReferenciaPedido.Length > 10)
                limite = false;
            else if (l.Bulto.Referencia.Length > 20)
                limite = false;
            else if (l.FechaPedido.Length > 10)
                limite = false;
            else if (l.Entrega.Nombre.Length > 100)
                limite = false;
            else if (l.Entrega.Direccion.Length > 100)
                limite = false;
            else if (l.Entrega.Ciudad.Length > 100)
                limite = false;
            else if (l.Entrega.Cp.Length > 100)
                limite = false;
            else if (l.Entrega.Telefonos.FirstOrDefault().Length > 12)
                limite = false;
            else if (l.NombreProveedor.Length > 100)
                limite = false;
            else if (l.Bulto.Descripcion.Length > 100)
                limite = false;
            else if (l.Bulto.Numero.Length > 5)
                limite = false;
            else if (l.Bulto.Peso.Length > 10)
                limite = false;
            else if (l.Bulto.CodigoAgencia.Length > 15)
                limite = false;

            return limite;
        }
        
    }
}
