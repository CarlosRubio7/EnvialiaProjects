using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_Servidor_Ftp
{
    class ImportExcel
    {
        public void RecogerDatosExcel(string ruta)
        {
            ConectarBD con = new ConectarBD();
            List<LineaPedido> lista = new List<LineaPedido>();

            //Declaro las variables necesarias
            Microsoft.Office.Interop.Excel._Application xlApp;
            Microsoft.Office.Interop.Excel._Workbook xlLibro;
            Microsoft.Office.Interop.Excel._Worksheet xlHoja1;
            Microsoft.Office.Interop.Excel.Sheets xlHojas;
            Microsoft.Office.Interop.Excel.Range range;
            //asigno la ruta dónde se encuentra el archivo
            string fileName = ruta;
            //inicializo la variable xlApp (referente a la aplicación)
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Muestra la aplicación Excel si está en true
            xlApp.Visible = false;
            //Abrimos el libro a leer (documento excel)
            xlLibro = xlApp.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            try
            {
                //Asignamos las hojas
                xlHojas = xlLibro.Sheets;
                //Asignamos la hoja con la que queremos trabajar: 
                xlHoja1 = (Microsoft.Office.Interop.Excel._Worksheet)xlHojas["Hoja1"];
                int j = 2;
                //Rango
                range = xlHoja1.UsedRange;

                //recorremos las celdas que queremos y sacamos los datos 
                for (int i = 0; i < range.Rows.Count; i++)
                {
                    string id = (string)xlHoja1.get_Range("A" + j, Missing.Value).Text;
                    string numero_pedido = (string)xlHoja1.get_Range("B" + j, Missing.Value).Text;
                    string key = (string)xlHoja1.get_Range("C" + j, Missing.Value).Text;
                    string fecha = (string)xlHoja1.get_Range("D" + j, Missing.Value).Text;
                    string nombre = (string)xlHoja1.get_Range("E" + j, Missing.Value).Text;
                    string direccion = (string)xlHoja1.get_Range("F" + j, Missing.Value).Text;
                    string poblacion = (string)xlHoja1.get_Range("G" + j, Missing.Value).Text;
                    string cod_postal = (string)xlHoja1.get_Range("H" + j, Missing.Value).Text;
                    string telefono = (string)xlHoja1.get_Range("I" + j, Missing.Value).Text;
                    string proveedor = (string)xlHoja1.get_Range("J" + j, Missing.Value).Text;
                    string descripcion = (string)xlHoja1.get_Range("K" + j, Missing.Value).Text;
                    string bultos = (string)xlHoja1.get_Range("L" + j, Missing.Value).Text;                    
                    string peso = (string)xlHoja1.get_Range("M" + j, Missing.Value).Text;
                    string referencia = (string)xlHoja1.get_Range("N" + j, Missing.Value).Text; 
                    string cod_tarifa = (string)xlHoja1.get_Range("O" + j, Missing.Value).Text; 
                    string reembolso = (string)xlHoja1.get_Range("P" + j, Missing.Value).Text;  
                    string retorno = (string)xlHoja1.get_Range("Q" + j, Missing.Value).Text;
                    string observaciones = (string)xlHoja1.get_Range("R" + j, Missing.Value).Text;
                    string etiquetas = (string)xlHoja1.get_Range("S" + j, Missing.Value).Text;
                    string stock = (string)xlHoja1.get_Range("T" + j, Missing.Value).Text;
                    string tipo_servicio = (string)xlHoja1.get_Range("U" + j, Missing.Value).Text;
//***INI*** MOD 21/11/2019 ***INI***//
                    string email = (string)xlHoja1.get_Range("V" + j, Missing.Value).Text;
//***FIN*** MOD 21/11/2019 ***FIN***//

                    Entrega entrega = new Entrega();                   
                    Bulto bulto = new Bulto();
                    Notas nota = new Notas();
                    LineaPedido linea = new LineaPedido(numero_pedido, key, fecha, entrega, proveedor,bulto, nota, retorno);

                    if (id != "")
                    {

                        con.ConexionBd();
                        //***INI*** MOD 21/11/2019 ***INI***//
                        //con.InsertarBd(numero_pedido, key, referencia, fecha, nombre, direccion, poblacion, cod_postal, telefono, proveedor,
                        //               descripcion, bultos, peso,cod_tarifa, reembolso, retorno, observaciones, stock, etiquetas, tipo_servicio);
                        con.InsertarBd(numero_pedido, key, referencia, fecha, nombre, direccion, poblacion, cod_postal, telefono, proveedor,
                                       descripcion, bultos, peso, cod_tarifa, reembolso, retorno, observaciones, stock, etiquetas, tipo_servicio, email);
                        //***FIN*** MOD 21/11/2019 ***FIN***//

                        /*linea.NumeroPedido = numero_pedido;
                        linea.ReferenciaPedido = key;
                        linea.FechaPedido = fecha;
                        linea.Entrega.Nombre = nombre;
                        linea.Entrega.Direccion = direccion;
                        linea.Entrega.Ciudad = poblacion;
                        linea.Entrega.Cp = cod_postal;
                        linea.Entrega.Telefonos[0] = telefono;
                        linea.NombreProveedor = proveedor;
                        linea.Bulto.Descripcion = descripcion;
                        linea.Bulto.Numero = bultos;
                        linea.Bulto.Peso = peso;
                        linea.Bulto.Referencia = referencia;
                        linea.Bulto.CodigoAgencia = cod_tarifa;
                        linea.Nota.Nota[0] = reembolso;
                        linea.Nota.Nota[1] = observaciones;                        
                        
                        lista.Add(cli);*/
                        j++;
                        con.DesconectarBd();
                    }
                }
            }

            finally
            {
                //Cerrar el Libro
                xlLibro.Close(false, Missing.Value, Missing.Value);
                //Cerrar la Aplicación
                xlApp.Quit();
            }

            //return lista;
        }
    }
}
