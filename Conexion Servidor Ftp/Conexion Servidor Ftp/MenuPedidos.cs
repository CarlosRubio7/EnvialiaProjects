using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

/****************************************************************************/
/********                                                            ********/
/********                        MENÚ PEDIDOS                        ********/
/********                                                            ********/
/****************************************************************************/
//
//************          MODIFICACIÓN 01/03/2018              ****************/
//
// NUEVA VERSIÓN EN LA QUE SE INCLUYEN LOS SIGUIENTES CAMBIOS:
// 1 - CAMBIAR EL ORDEN DE LAS COLUMNAS AL LISTAR LOS PEDIDOS
// 2 - INCLUIR UNA COLUMNA CON EL TIPO DE SERVICIO(MODIFICABLE)
//***INI*** MOD 01/03/2018 ***INI***//
//***FIN*** MOD 01/03/2018 ***FIN***//
//
//************          MODIFICACIÓN 01/03/2018              ****************/
//************          MODIFICACIÓN 21/11/2019              ****************/
//
// NUEVA VERSIÓN EN LA QUE SE INCLUYEN LOS SIGUIENTES CAMBIOS:
// 1 - INCLUIR UNA COLUMNA CON EL MAIL
//***INI*** MOD 21/11/2019 ***INI***//
//***FIN*** MOD 21/11/2019 ***FIN***//
//
//************          MODIFICACIÓN 21/11/2019              ****************/

namespace Conexion_Servidor_Ftp
{
    public partial class MenuPedidos : Form
    {
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        DataGridViewComboBoxColumn chk2 = new DataGridViewComboBoxColumn();
        ConectarBD con = null;
        ImportExcel import;
        Exportar export;
        string dato;
        bool vacio;
        string folderpath = "C:\\FICHEROS FTP\\";
        public string Dato
        {
            get
            {
                return dato;
            }
            set
            {
                dato = value;
            }
        }
        public MenuPedidos()
        {
            InitializeComponent();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                     BOTÓN - CANCELAR                       ********/
        /********                                                            ********/
        /****************************************************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                BOTÓN - BUSCAR RUTA ORIGEN                  ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_buscar_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                tb_ruta.Text = folderName;
            }
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                 BOTÓN - BÚSQUEDA POR CAMPO                 ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_buscar1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
            {
                for (int j = 0; j <= dataGridView1.Rows.Count - 2; j++)
                {
                    if (dataGridView1.Columns[i].HeaderText == comboBox1.Text)
                    {
                        if (dataGridView1.Rows[j].Cells[i].Value.ToString().Replace(" ", "") == textBox1.Text.Replace(" ", ""))
                        {
                            dataGridView1.Rows[j].Selected = true;
                            dataGridView1.CurrentCell = dataGridView1.Rows[j].Cells[i];
                            break;

                        }
                    }
                }
            }            
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                     BOTÓN - CONECTAR                       ********/
        /********                                                            ********/
        /****************************************************************************/
        /// 1 - Conecto con el servidor ftp
        /// 2 - Descargo los ficheros a local
        /// 3 - Leo el contenido de los ficheros
        /// 4 - Inserto los datos de los ficheros en el data grid
        /// 5 - Refrescar stock
        private void bt_conectar_Click_1(object sender, EventArgs e)
        {
            con = new ConectarBD();
            con.ConexionBd();
            var ftp = new FtpSettings
            {
                Port = 21,
                Server = "backend.latiendahome.com",
//***INI*** MOD 01/03/2018 ***INI***//
                //RemoteFolderPath = "/pedidos",
                RemoteFolderPath = "/pedidos/old/pruebapedidos",
//***FIN*** MOD 01/03/2018 ***FIN***//
                User = "envialia",
                Password = "c1a009859f304bb0bd7bc6b9ac159f2f"

            };
            try
            {

                //Conectamos con las credenciales anteriores al servidor
                FtpHelper ftphelper = new FtpHelper(ftp);
                //Obtenemos el listado de ficheros del servidor ftp
                List<FtpFile> listaFicheros = ftphelper.GetRemoteFiles();

                if (tb_ruta.Text != "")
                {
                    //Descargamos los ficheros obtenidos en una carpeta local
                    ftphelper.WriteFiles(listaFicheros, tb_ruta.Text);
                    //Pasamos los ficheros descargados a local a la carpeta de backup del servidor ftp
                    ftphelper.WriteFilesBackupFtp(listaFicheros);
                    //Leemos los ficheros de la carpeta y los guardamos en la base de datos
                    this.LeerFicheros(listaFicheros, tb_ruta.Text);
                    //Creamos un directorio Backup para mover los ficheros leidos e insertados en la base de datos
                    this.generar_backup(tb_ruta.Text);
                    //Creamos un datagrid
                    this.CrearDataGrid(dataGridView1);
                    //Rellenamos el ComboBox
                    this.RellenarComboBox();
                    //Actualizamos el datagrid con los datos de la base de datos
                    this.Refresh();
                    //***INI*** MOD 01/03/2018 ***INI***//
                    //this.cargar_combobox();
                    //***FIN*** MOD 01/03/2018 ***FIN***//

                    if (dataGridView1.RowCount > 0)
                    {
                        groupBox1.Enabled = true;
                        groupBox3.Enabled = true;
                        bt_traspasar_destino.Enabled = true;
                        groupBox5.Enabled = true;
                    }

                    if (dataGridView2.RowCount > 0)
                    {
                        bt_traspasar_origen.Enabled = true;
                        bt_generar.Enabled = true;
                        bt_clear.Enabled = true;                        
                    }

                    con.DesconectarBd();
                }
                else
                {
                    MessageBox.Show("Error, la ruta de origen no se encuentra!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("There was an error connecting to the FTP Server.");
                con.DesconectarBd();
            }   
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                      BOTÓN - GUARDAR                       ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_guardar_cambios_Click(object sender, EventArgs e)
        {
            ConectarBD con = new ConectarBD();
            con.ConexionBd();
            string id = "";
            string tipo_servicio = "";
            string stock = "";

            try
            {
                // Se recorre cada registro del datagrid de origen
                //
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //
                    // Se recupera el campo que representa el checkbox, y se valida la seleccion
                    // agregandola a la lista temporal
                    //
                    DataGridViewCheckBoxCell cellSeleccion = row.Cells["chk"] as DataGridViewCheckBoxCell;
                    if (row.Cells["Id"].Value.ToString() != null)
                    {
                        if (Convert.ToBoolean(cellSeleccion.Value))
                        {
                            id = row.Cells["Id"].Value.ToString();
                            tipo_servicio = row.Cells["Servicio"].Value.ToString();
                            stock = "SI";
                            //con.UpdateStockBd(id, stock);
                            con.UpdateServicioStockBd(id, tipo_servicio, stock);
                        } 
                        else
                        {
                            id = row.Cells["Id"].Value.ToString();
                            tipo_servicio = row.Cells["Servicio"].Value.ToString();
                            stock = "NO";
                            //con.UpdateStockBd(id, stock);
                            con.UpdateServicioStockBd(id, tipo_servicio, stock);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                String msg = "Error al modificar los datos" + "Details:" + '\n' + ex.ToString();
                MessageBox.Show(msg);
            }

            con.DesconectarBd();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                     BOTÓN - MODIFICAR                      ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_modificar_Click(object sender, EventArgs e)
        {
            con.ConexionBd();
            dato = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            if (dato != null)
            {
                Modificar frm = new Modificar();
                frm.Dato_mod = dato;
                frm.ShowDialog();
            }

            this.Refresh();
            con.DesconectarBd();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                       BOTÓN - BORRAR                       ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_borrar_Click(object sender, EventArgs e)
        {
            con.ConexionBd();
            dato = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            try
            {
                con.DeleteBd(dato.Replace(" ", ""));
                this.Refresh();
            }
            catch (Exception ex)
            {
                String msg = "Error al borrar los datos" + "Details:" + '\n' + ex.ToString();
                MessageBox.Show(msg);
            }

            con.DesconectarBd();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                       BOTÓN - GENERAR                      ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_generar_Click(object sender, EventArgs e)
        {
            con.ConexionBd();
            string dato = "";
            //dato = dataGridView2.CurrentRow.Cells["Id"].Value.ToString();
            try
            {
                export = new Exportar();
                export.ExportarDatagridExcel(dataGridView2);
                dataGridView2.Refresh();
                // Se recorre cada registro del datagrid de origen
                //
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["Id"].Value.ToString() != null)
                    {
                        dato = row.Cells["Id"].Value.ToString();
                        con.DeleteBd(dato.Replace(" ", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                String msg = "Error al borrar los datos" + "Details:" + '\n' + ex.ToString();
                MessageBox.Show(msg);
            }

            con.DesconectarBd();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                 BOTÓN - TRASPASAR  DESTINO                 ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_traspasar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
            //dataGridView2.Refresh();
            if(dataGridView2.RowCount == 0)
            {
                //Creamos un datagrid
                this.CrearDataGrid(dataGridView2);
            }

            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    DataGridViewCheckBoxCell cellSeleccion = dataGridView1.SelectedRows[i].Cells["chk"] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(cellSeleccion.Value))
                    {
                        rowSelected.Add(dataGridView1.SelectedRows[i]);
                    }
                }
            }            

            //
            // Se agrega el item seleccionado a la grilla de destino
            // eliminando la fila de la grilla original
            //
            foreach (DataGridViewRow row in rowSelected)
            {
                dataGridView2.Rows.Add(new object[] {
                                            row.Cells["Nº Pedido"].Value,
                                            row.Cells["Nº Key"].Value,
                                            row.Cells["Proveedor"].Value,
                                            row.Cells["Código de tarifa"].Value,
                                            row.Cells["Destinatario"].Value,
                                            row.Cells["Id"].Value,                                            
                                            row.Cells["Fecha pedido"].Value,
                                            row.Cells["Dirección"].Value,                                          
                                            row.Cells["Población"].Value,
                                            row.Cells["Código postal"].Value,
                                            row.Cells["Teléfono"].Value,
                                            row.Cells["Descripción producto"].Value,
                                            row.Cells["Bultos"].Value,
                                            row.Cells["Peso"].Value,
                                            row.Cells["Referencia producto"].Value,                                            
                                            row.Cells["Reembolso"].Value,
                                            row.Cells["Retorno"].Value,
                                            row.Cells["Observaciones"].Value,
//***INI*** MOD 01/03/2018 ***INI***//
                                            row.Cells["Etiquetas"].Value,
                                            row.Cells["Servicio"].Value, 
//***FIN*** MOD 01/03/2018 ***FIN***//
//***INI*** MOD 21/11/2019 ***INI***//
                                            row.Cells["Mail"].Value, 
//***FIN*** MOD 21/11/2019 ***FIN***//
                                            row.Cells["chk"].Value                                          
                                            });

                dataGridView1.Rows.Remove(row);

                if (dataGridView2.RowCount > 0)
                {
                    bt_traspasar_origen.Enabled = true;
                    bt_generar.Enabled = true;
                    bt_clear.Enabled = true;
                }
            }
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                      BOTÓN - IMPORTAR                      ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_importar_Click(object sender, EventArgs e)
        {
            ImportarBDD frm = new ImportarBDD();
            frm.ShowDialog();
            //con.ConexionBd();
            this.CrearDataGrid(dataGridView1);
            this.Refresh();
            //con.DesconectarBd();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                      BOTÓN - EXPORTAR                      ********/
        /********                                                            ********/
        /****************************************************************************/
        private void bt_exportar_Click(object sender, EventArgs e)
        {
            con.ConexionBd();

            try
            {
                export = new Exportar();
                export.ExportarDatagridExcel(dataGridView1);
            }
            catch (Exception ex)
            {
                String msg = "Error al exportar los datos" + "Details:" + '\n' + ex.ToString();
                MessageBox.Show(msg);
            }

            con.DesconectarBd();
        }

        private void bt_traspasar_origen_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
            dataGridView1.Refresh();

            Int32 selectedRowCount = dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    DataGridViewCheckBoxCell cellSeleccion = dataGridView2.SelectedRows[i].Cells["chk"] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(cellSeleccion.Value))
                    {
                        rowSelected.Add(dataGridView2.SelectedRows[i]);
                    }
                }
            }
            //this.Refresh();
            //
            // Se agrega el item seleccionado a la grilla de destino
            // eliminando la fila de la grilla original
            //
            foreach (DataGridViewRow row in rowSelected)
            {
                dataGridView1.Rows.Add(new object[] {
                                            row.Cells["Nº Pedido"].Value,
                                            row.Cells["Nº Key"].Value,
                                            row.Cells["Proveedor"].Value,
                                            row.Cells["Código de tarifa"].Value,
                                            row.Cells["Destinatario"].Value,
                                            row.Cells["Id"].Value,                                            
                                            row.Cells["Fecha pedido"].Value,
                                            row.Cells["Dirección"].Value,                                          
                                            row.Cells["Población"].Value,
                                            row.Cells["Código postal"].Value,
                                            row.Cells["Teléfono"].Value,
                                            row.Cells["Descripción producto"].Value,
                                            row.Cells["Bultos"].Value,
                                            row.Cells["Peso"].Value,
                                            row.Cells["Referencia producto"].Value,                                            
                                            row.Cells["Reembolso"].Value,
                                            row.Cells["Retorno"].Value,
                                            row.Cells["Observaciones"].Value,
//***INI*** MOD 01/03/2018 ***INI***//
                                            row.Cells["Etiquetas"].Value,
                                            row.Cells["Servicio"].Value, 
//***FIN*** MOD 01/03/2018 ***FIN***//
//***INI*** MOD 21/11/2019 ***INI***//
                                            row.Cells["Mail"].Value, 
//***FIN*** MOD 21/11/2019 ***FIN***//
                                            row.Cells["chk"].Value                                          
                                            });

                dataGridView2.Rows.Remove(row);

            }
            this.colorear_filas();


        }

        /****************************************************************************/
        /********                                                            ********/
        /********                     BOTÓN - LIMPIAR                        ********/
        /********                                                            ********/
        /****************************************************************************/
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********             MÉTODO - CREAR CABECERA DATAGRID               ********/
        /********                                                            ********/
        /****************************************************************************/
        private void CrearDataGrid(DataGridView datagrid)
        {
            this.Controls.Add(datagrid);
//***INI*** MOD 01/03/2018 ***INI***//
            //datagrid.ColumnCount = 19;
            datagrid.ColumnCount = 21;
//***FIN*** MOD 01/03/2018 ***FIN***//

            datagrid.Columns[0].Name = "Nº Pedido";
            datagrid.Columns[1].Name = "Nº Key";
            datagrid.Columns[2].Name = "Proveedor";
            datagrid.Columns[3].Name = "Código de tarifa";
            datagrid.Columns[4].Name = "Destinatario";
            datagrid.Columns[5].Name = "Id";
            datagrid.Columns[6].Name = "Fecha pedido";
            datagrid.Columns[7].Name = "Dirección";
            datagrid.Columns[8].Name = "Población";
            datagrid.Columns[9].Name = "Código postal";
            datagrid.Columns[10].Name = "Teléfono";
            datagrid.Columns[11].Name = "Descripción producto";
            datagrid.Columns[12].Name = "Bultos";
            datagrid.Columns[13].Name = "Peso";
            datagrid.Columns[14].Name = "Referencia producto";
            datagrid.Columns[15].Name = "Reembolso";
            datagrid.Columns[16].Name = "Retorno";
            datagrid.Columns[17].Name = "Observaciones";
//***INI*** MOD 01/03/2018 ***INI***//
            datagrid.Columns[18].Name = "Etiquetas";
            datagrid.Columns[19].Name = "Servicio";

//          chk2 = new DataGridViewComboBoxColumn();
//          datagrid.Columns.Add(chk2);
//          chk2.HeaderText = "Tipo servicio";
//          chk2.Name = "Servicio";
//***FIN*** MOD 01/03/2018 ***FIN***//
//***INI*** MOD 21/11/2019 ***INI***//
            datagrid.Columns[20].Name = "Mail";
//***FIN*** MOD 21/11/2019 ***FIN***//
            chk = new DataGridViewCheckBoxColumn();
            datagrid.Columns.Add(chk);
            chk.HeaderText = "Stock";
            chk.Name = "chk";
       
            
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                 MÉTODO - RELLENAR COMBOBOX                 ********/
        /********                                                            ********/
        /****************************************************************************/
        private void RellenarComboBox()
        {
            comboBox1.Items.Add("Nº Pedido");
            comboBox1.Items.Add("Nº Key");
            comboBox1.Items.Add("Proveedor");
            comboBox1.Items.Add("Código de tarifa");
            comboBox1.Items.Add("Destinatario");
            comboBox1.Items.Add("Id");
            comboBox1.Items.Add("Fecha pedido");
            comboBox1.Items.Add("Dirección");
            comboBox1.Items.Add("Población");
            comboBox1.Items.Add("Código postal");
            comboBox1.Items.Add("Teléfono");
            comboBox1.Items.Add("Descripción producto");
            comboBox1.Items.Add("Bultos");
            comboBox1.Items.Add("Peso");
            comboBox1.Items.Add("Referencia producto");
            comboBox1.Items.Add("Reembolso");
            comboBox1.Items.Add("Retorno");
            comboBox1.Items.Add("Observaciones");
//***INI*** MOD 01/03/2018 ***INI***//
            comboBox1.Items.Add("Etiquetas");
            comboBox1.Items.Add("Tipo servicio");
//***FIN*** MOD 01/03/2018 ***FIN***//

        }

        /****************************************************************************/
        /********                                                            ********/
        /********                      MÉTODO - REFRESCAR                    ********/
        /********                                                            ********/
        /****************************************************************************/
        public override void Refresh()
        {
            bool stock = false;
            con = new ConectarBD();
            con.ConexionBd();

            this.dataGridView1.Rows.Clear();
//***INI*** MOD 01/03/2018 ***INI***//
            foreach (ConectarBD p in con.CargarDatos())
            //foreach (ConectarBD p in con.PedidosServicios())
//***FIN*** MOD 01/03/2018 ***FIN***//
            {
                //int i = 0;
                if (p.Stock == "SI")
                {
                    stock = true;
                }
                else
                {
                    stock = false;
                }

                dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
//***INI*** MOD 01/03/2018 ***INI***//
                //dataGridView1.Rows.Add(p.Num_pedido, p.Num_key, p.Proveedor, p.Cod_tarifa, p.Destinatario, p.Id, p.Fecha_pedido, p.Direccion, p.Poblacion,
                //                       p.Cod_postal, p.Telefono, p.Descripcion_producto, p.Bultos, p.Peso, p.Ref_producto,
                //                       p.Reembolso, p.Retorno, p.Observaciones, stock);
                //dataGridView1.Rows.Add(p.Num_pedido, p.Num_key, p.Proveedor, p.Cod_tarifa, p.Destinatario, p.Id, p.Fecha_pedido, p.Direccion, p.Poblacion,
                //     p.Cod_postal, p.Telefono, p.Descripcion_producto, p.Bultos, p.Peso, p.Ref_producto,
                //     p.Reembolso, p.Retorno, p.Observaciones, p.Etiqueta, p.Servicio, stock);
                
//***FIN*** MOD 01/03/2018 ***FIN***//
//***INI*** MOD 21/11/2019 ***INI***//
                dataGridView1.Rows.Add(p.Num_pedido, p.Num_key, p.Proveedor, p.Cod_tarifa, p.Destinatario, p.Id, p.Fecha_pedido, p.Direccion, p.Poblacion,
                                       p.Cod_postal, p.Telefono, p.Descripcion_producto, p.Bultos, p.Peso, p.Ref_producto,
                                       p.Reembolso, p.Retorno, p.Observaciones, p.Etiqueta, p.Servicio, p.Email, stock);
//***FIN*** MOD 01/03/2018 ***FIN***//


            }
            colorear_filas();
            con.DesconectarBd();
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                    MÉTODO - LEER FICHEROS                  ********/
        /********                                                            ********/
        /****************************************************************************/
        //- Leemos el contenido de los ficheros
        //- Insertamos los datos de los ficheros en una base de datos
        private void LeerFicheros(List<FtpFile> listaFiles, string ruta_fichero)
        {
            //String folderPath = @"C:\FICHEROS FTP";

            foreach (string file in Directory.EnumerateFiles(ruta_fichero, "*.xml"))
            {
                EnvialiaFileReader envialiaFileReader = new EnvialiaFileReader();
                String texto = envialiaFileReader.readFile(file);

                if (texto != null)
                {
                    Pedido pedido;
                    var serializer = new XmlSerializer(typeof(Pedido));

                    using (var stream = new StringReader(texto))
                    using (var reader = XmlReader.Create(stream))
                    {
                        pedido = (Pedido)serializer.Deserialize(reader);

                        List<LineaPedido> lineasPedido = pedido.getLineasPedido();
                        InsertarBd(lineasPedido);
                        
                    }
                }
            }
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                    MÉTODO - INSERTAR BDD                   ********/
        /********                                                            ********/
        /****************************************************************************/
        private void InsertarBd(List<LineaPedido> listaArticulos)
        {
            vacio = false;
            ConectarBD con = new ConectarBD();
            Validaciones val = new Validaciones();
            string valor_reembolso = "";
            string observaciones = "";
            string retorno = "";

            if (vacio == false)
            {
                try
                {
                    con.ConexionBd();
                    foreach (LineaPedido l in listaArticulos)
                    {
                        if (val.comprobar_tamaño_campos(l))
                        {
                            if (l.Nota.Nota.Count > 0)
                            {
                                valor_reembolso = l.Nota.Nota[0];
                                if (l.Nota.Nota.Count > 1)
                                {
                                    if (l.Nota.Nota[1].Length >= 100)
                                    {
                                        observaciones = l.Nota.Nota[1].Remove(0, 100);
                                    }
                                    else
                                    {
                                        observaciones = "Fecha de entrega:" + l.Nota.Nota[1];                                        
                                    }
                                }
                                else
                                {
                                    observaciones = "";
                                }
                            }
                            else
                            {
                                valor_reembolso = "0";
                            }

                            if (l.Retorno == "0")
                            {
                                retorno = "NO";
                            }
                            else
                            {
                                retorno = "SI";
                            }
                            if (con.CargarDatos().Count == 0)
                            {
//***INI*** MOD 21/11/2019 ***INI***//
//                                if (l.Bulto.CodigoAgencia == "EN000000001")
//                                {
//                                   if (con.ConsultarArtProveedor(l.NumeroPedido, l.NombreProveedor, l.Bulto.CodigoAgencia) == false)
//                                    {
//                                        con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
//                                                    l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
//                                                    valor_reembolso, retorno, observaciones, "NO", l.Bulto.Etiqueta, "24");
//                                    }

//                                }
//                                else
//                                {
                                    //con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
                                    //              l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
                                    //            valor_reembolso, retorno, observaciones, "NO");
//                                    con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
//                                                    l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
//                                                    valor_reembolso, retorno, observaciones, "NO", l.Bulto.Etiqueta, "24");
//                                }
//***FIN*** MOD 01/03/2018 ***FIN***//
//***INI*** MOD 21/11/2019 ***INI***//
//                                if (l.Bulto.CodigoAgencia == "EN000000001")
//                                {
//                                    if (con.ConsultarArtProveedor(l.NumeroPedido, l.NombreProveedor, l.Bulto.CodigoAgencia) == false)
//                                    {
//                                        con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
//                                                    l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
//                                                    valor_reembolso, retorno, observaciones, "NO", l.Bulto.Etiqueta, "24");
//                                    }

//                                }
//                                else
//                                {
//                                    con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
//                                                    l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
//                                                    valor_reembolso, retorno, observaciones, "NO", l.Bulto.Etiqueta, "24");
                                if (l.Bulto.CodigoAgencia == "EN000000001")
                                {
                                    if (con.ConsultarArtProveedor(l.NumeroPedido, l.NombreProveedor, l.Bulto.CodigoAgencia) == false)
                                    {
                                        con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
                                                    l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
                                                    valor_reembolso, retorno, observaciones, "NO", l.Bulto.Etiqueta, "24", l.Entrega.Email);
                                    }

                                }
                                else
                                {
                                    con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
                                                    l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
                                                    valor_reembolso, retorno, observaciones, "NO", l.Bulto.Etiqueta, "24", l.Entrega.Email);
                                }
                                
//***FIN*** MOD 01/03/2018 ***FIN***//
                            }
                            else
                            {
//***INI*** MOD 01/03/2018 ***INI***//
                                if (l.Bulto.CodigoAgencia == "EN000000001")
                                {
                                    if (con.ConsultarArtProveedor(l.NumeroPedido, l.NombreProveedor, l.Bulto.CodigoAgencia) == false)
                                    {
                                        con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
                                                    l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
                                                    valor_reembolso, retorno, observaciones, "NO", l.Bulto.Etiqueta, "24", l.Entrega.Email);
                                    }

                                }
                                else
                                {
                                    //con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
                                    //              l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
                                    //            valor_reembolso, retorno, observaciones, "NO");
                                    con.InsertarBd(l.NumeroPedido, l.ReferenciaPedido, l.Bulto.Referencia, l.FechaPedido, l.Entrega.Nombre, l.Entrega.Direccion, l.Entrega.Ciudad,
                                                    l.Entrega.Cp, l.Entrega.Telefonos[0], l.NombreProveedor, l.Bulto.Descripcion, l.Bulto.Numero, l.ObtenerPeso(l.Bulto.CodigoAgencia), l.Bulto.CodigoAgencia,
                                                    valor_reembolso, retorno, observaciones, "NO", l.Bulto.Etiqueta, "24", l.Entrega.Email);
                                }
//***FIN*** MOD 01/03/2018 ***FIN***//
                            }
                        }
                    }

                    con.DesconectarBd();
                }
                catch (Exception ex)
                {
                    String msg = "Error al guardar los datos" + "Details:" + '\n' + ex.ToString();
                    MessageBox.Show(msg);
                }
            } 
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                      MÉTODO - BACKUP                       ********/
        /********                                                            ********/
        /****************************************************************************/
        private void generar_backup(string directorio_raiz )
        {
            DirectoryInfo dir = new DirectoryInfo(directorio_raiz);
            //Crear una nueva subcarpeta en el directorio raiz
            string newPath = System.IO.Path.Combine(directorio_raiz, "Backup");
            string newPath2 = System.IO.Path.Combine(newPath, DateTime.Today.ToString("dd-MM-yyyy"));
            string newPath3 = "";

            if (System.IO.File.Exists(newPath))
            {
                //Crear la subcarpeta
                System.IO.Directory.CreateDirectory(newPath);

                if(!System.IO.File.Exists(newPath2))
                {
                    //Crear la subcarpeta
                    System.IO.Directory.CreateDirectory(newPath2);
                    foreach (var f in dir.GetFiles())
                    {
                        string pathOrigen = directorio_raiz + "\\";
                        pathOrigen = System.IO.Path.Combine(pathOrigen, f.Name);
                        newPath3 = System.IO.Path.Combine(newPath2, f.Name);

                        if (!System.IO.File.Exists(newPath3))
                        {
                            File.Move(pathOrigen, newPath3);
                            File.Delete(pathOrigen);
                        }
                        else
                        {
                            File.Delete(pathOrigen);
                        }
                    }
                }
            }
            else
            {
                if (!System.IO.File.Exists(newPath2))
                {
                    //Crear la subcarpeta
                    System.IO.Directory.CreateDirectory(newPath2);
                    foreach (var f in dir.GetFiles("*.xml"))
                    {
                        string pathOrigen = directorio_raiz + "\\";
                        pathOrigen = System.IO.Path.Combine(pathOrigen, f.Name);
                        newPath3 = System.IO.Path.Combine(newPath2, f.Name);

                        if (!System.IO.File.Exists(newPath3))
                        {
                            File.Move(pathOrigen, newPath3);
                            File.Delete(pathOrigen);
                        }
                        else
                        {
                            File.Delete(pathOrigen);
                        }
                    }
                }
            }
        }

         /****************************************************************************/
        /********                                                            ********/
        /********                      MÉTODO - COLOREAR                     ********/
        /********                                                            ********/
        /****************************************************************************/
        private void colorear_filas()
        {
            try
            {
                // Se recorre ca registro de la grilla de origen
                //
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Se selecciona la celda del checkbox
                    //
                    DataGridViewCheckBoxCell cellSelecion = row.Cells["chk"] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(cellSelecion.Value))
                        row.DefaultCellStyle.BackColor = Color.Green;
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                String msg = "Error al colorear las celdas" + "Details:" + '\n' + ex.ToString();
                MessageBox.Show(msg);
            }
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                 MÉTODO - BÚSQUEDA PARCIAL                  ********/
        /********                                                            ********/
        /****************************************************************************/
        private void busqueda_parcial(string cadena_busqueda)
        {
            List<DataGridViewRow> rows = (from item in dataGridView1.Rows.Cast<DataGridViewRow>()
                                          let id = Convert.ToString(item.Cells["Id"].Value ?? string.Empty)
                                          let pedido = Convert.ToString(item.Cells["Nº Pedido"].Value ?? string.Empty)
                                          let key = Convert.ToString(item.Cells["Nº Key"].Value ?? string.Empty)
                                          let fecha_pedido = Convert.ToString(item.Cells["Fecha pedido"].Value ?? string.Empty)
                                          let destinatario = Convert.ToString(item.Cells["Destinatario"].Value ?? string.Empty)
                                          let direccion = Convert.ToString(item.Cells["Dirección"].Value ?? string.Empty)
                                          let poblacion = Convert.ToString(item.Cells["Población"].Value ?? string.Empty)
                                          let codigo_postal = Convert.ToString(item.Cells["Código postal"].Value ?? string.Empty)
                                          let telefono = Convert.ToString(item.Cells["Teléfono"].Value ?? string.Empty)
                                          let proveedor = Convert.ToString(item.Cells["Proveedor"].Value ?? string.Empty)
                                          let descripcion_producto = Convert.ToString(item.Cells["Descripción producto"].Value ?? string.Empty)
                                          let bultos = Convert.ToString(item.Cells["Bultos"].Value ?? string.Empty)
                                          let peso = Convert.ToString(item.Cells["Peso"].Value ?? string.Empty)
                                          let referencia = Convert.ToString(item.Cells["Referencia producto"].Value ?? string.Empty)
                                          let cod_tarifa = Convert.ToString(item.Cells["Código de tarifa"].Value ?? string.Empty)
                                          let reembolso = Convert.ToString(item.Cells["Reembolso"].Value ?? string.Empty)
                                          let retorno = Convert.ToString(item.Cells["Retorno"].Value ?? string.Empty)
                                          let observaciones = Convert.ToString(item.Cells["Observaciones"].Value ?? string.Empty)
                                          let etiquetas = Convert.ToString(item.Cells["Etiquetas"].Value ?? string.Empty)
                                          //let stock = Convert.ToString(item.Cells["Stock"].Value ?? string.Empty)
                                          where id.Contains(cadena_busqueda) ||
                                                pedido.Contains(cadena_busqueda) ||
                                                key.Contains(cadena_busqueda) ||
                                                fecha_pedido.Contains(cadena_busqueda) ||
                                                destinatario.Contains(cadena_busqueda) ||
                                                direccion.Contains(cadena_busqueda) ||
                                                poblacion.Contains(cadena_busqueda) ||
                                                codigo_postal.Contains(cadena_busqueda) ||
                                                telefono.Contains(cadena_busqueda) ||
                                                proveedor.Contains(cadena_busqueda) ||
                                                descripcion_producto.Contains(cadena_busqueda) ||
                                                bultos.Contains(cadena_busqueda) ||
                                                referencia.Contains(cadena_busqueda) ||
                                                cod_tarifa.Contains(cadena_busqueda) ||
                                                reembolso.Contains(cadena_busqueda) ||
                                                retorno.Contains(cadena_busqueda) ||
                                                observaciones.Contains(cadena_busqueda) ||
                                                etiquetas.Contains(cadena_busqueda) 
                                                //stock.Contains(cadena_busqueda)
                                          select item).ToList<DataGridViewRow>();

            foreach (DataGridViewRow row in rows)
            {
                List<DataGridViewCell> cells = (from item in row.Cells.Cast<DataGridViewCell>()
                                                let cell = Convert.ToString(item.Value)
                                                where cell.Contains(cadena_busqueda)
                                                select item).ToList<DataGridViewCell>();

                foreach (DataGridViewCell item in cells)
                {
                    item.Selected = true;
                }

            }
        }

//***INI*** MOD 01/03/2018 ***INI***//
        /****************************************************************************/
        /********                                                            ********/
        /********                  MÉTODO - CARGAR COMBOBOX                  ********/
        /********                                                            ********/
        /****************************************************************************/
        private void cargar_combobox()
        {
            ConectarBD con = new ConectarBD();
            con.ConexionBd();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string idPedido = row.Cells["Id"].Value.ToString();
                DataGridViewComboBoxColumn comboboxColumn = dataGridView1.Columns["Servicio"] as DataGridViewComboBoxColumn;

                comboboxColumn.DataSource = con.ConsultarIdBd(idPedido);
                comboboxColumn.ValueMember = "tipo_servicio";
                comboboxColumn.DisplayMember = "tipo_servicio";
            }
            con.DesconectarBd();
        }
//***INI*** MOD 01/03/2018 ***INI***//
            
        /****************************************************************************/
        /********                                                            ********/
        /********                   EVENTO - CELLCLICK                       ********/
        /********                                                            ********/
        /****************************************************************************/
        /* private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
                label2.Text = dataGridView1.Columns[e.ColumnIndex].HeaderText.ToString();
        }*/

        /****************************************************************************/
        /********                                                            ********/
        /********               EVENTO - KEY DOWN(BÚSQUEDA)                  ********/
        /********                                                            ********/
        /****************************************************************************/
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    for (int j = 0; j <= dataGridView1.Rows.Count -2; j++)
                    {
                        if (dataGridView1.Columns[i].HeaderText == comboBox1.Text)
                        {
                            if (dataGridView1.Rows[j].Cells[i].Value.ToString().Replace(" ", "") == textBox1.Text.Replace(" ", ""))
                            {
                                dataGridView1.Rows[j].Selected = true;
                                dataGridView1.CurrentCell = dataGridView1.Rows[j].Cells[i];
                                break;
                            }
                        }
                    }
                }                
            }*/
            if (e.KeyCode == Keys.Enter)
            {
                busqueda_parcial(textBox1.Text);
            }
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                EVENTO - CELLCONTENTCLICK                   ********/
        /********                                                            ********/
        /****************************************************************************/
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            // Detecta si se ha seleccionado el header de la grilla
            //
            if (e.RowIndex == -1)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "chk")
            {
                //
                // Se toma la fila seleccionada
                //
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                //
                // Se selecciona la celda del checkbox
                //
                DataGridViewCheckBoxCell cellSelecion = row.Cells["chk"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                    row.DefaultCellStyle.BackColor = Color.Green;
                else
                    row.DefaultCellStyle.BackColor = Color.White;

            }

        }

        /****************************************************************************/
        /********                                                            ********/
        /********         EVENTO - CURRENTCELLDIRTYSTATECHANGED              ********/
        /********                                                            ********/
        /****************************************************************************/
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /****************************************************************************/
        /********                                                            ********/
        /********                       EVENTO - LOAD                        ********/
        /********                                                            ********/
        /****************************************************************************/
        private void MenuPedidos_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            bt_generar.Enabled = false;
            bt_traspasar_destino.Enabled = false;
            bt_traspasar_origen.Enabled = false;
            bt_clear.Enabled = false;

        }

//***INI*** MOD 01/03/2018 ***INI***//
        /****************************************************************************/
        /********                                                            ********/
        /********            EVENTO - SELECTED INDEX CHANGED                 ********/
        /********                                                            ********/
        /****************************************************************************/
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item seleccion = comboBox1.SelectedItem as Item;

            if (seleccion == null)
                return;

            MessageBox.Show(string.Format("Se ha seleccionado Servicio: {0} Valor: {1}",
                                                        seleccion.Name,
                                                        seleccion.Value));

        }

        private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception == null) return;

            // If the user-specified value is invalid, cancel the change 
            // and display the error icon in the row header.
            if ((e.Context & DataGridViewDataErrorContexts.Commit) != 0 &&
                (typeof(FormatException).IsAssignableFrom(e.Exception.GetType()) ||
                typeof(ArgumentException).IsAssignableFrom(e.Exception.GetType())))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "The specified value is invalid.";
                e.Cancel = true;
            }
            else
            {
                // Rethrow any exceptions that aren't related to the user input.
                e.ThrowException = true;
            }
        }

//***INI*** MOD 01/03/2018 ***INI***//















    }
}
