using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

/****************************************************************************/
/********                                                            ********/
/********                          ConectarBD                        ********/
/********                                                            ********/
/****************************************************************************/

namespace Conexion_Servidor_Ftp
{
    public class ConectarBD
    {
        SqlCeConnection conn = null;
        string valor = "";
        string id;
        string num_pedido;
        string num_key;
        string ref_producto;
        string fecha_pedido;
        string destinatario;
        string direccion;
        string poblacion;
        string cod_postal;
        string telefono;
        string proveedor;
        string descripcion_producto;
        string bultos;
        string peso;
        string cod_tarifa;
        string reembolso;
        string retorno;
        string observaciones;
        string etiqueta;
        string tipo_servicio;
        string stock;
        string email;


        public string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Num_pedido
        {
            get
            {
                return num_pedido;
            }
            set
            {
                num_pedido = value;
            }
        }
        public string Num_key
        {
            get
            {
                return num_key;
            }
            set
            {
                num_key = value;
            }
        }
        public string Ref_producto
        {
            get
            {
                return ref_producto;
            }
            set
            {
                ref_producto = value;
            }
        }
        public string Fecha_pedido
        {
            get
            {
                return fecha_pedido;
            }
            set
            {
                fecha_pedido = value;
            }
        }
        public string Destinatario
        {
            get
            {
                return destinatario;
            }
            set
            {
                destinatario = value;
            }
        }
        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }
        public string Poblacion
        {
            get
            {
                return poblacion;
            }
            set
            {
                poblacion = value;
            }
        }
        public string Cod_postal
        {
            get
            {
                return cod_postal;
            }
            set
            {
                cod_postal = value;
            }
        }
        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }
        public string Proveedor
        {
            get
            {
                return proveedor;
            }
            set
            {
                proveedor = value;
            }
        }
        public string Descripcion_producto
        {
            get
            {
                return descripcion_producto;
            }
            set
            {
                descripcion_producto = value;
            }
        }
        public string Bultos
        {
            get
            {
                return bultos;
            }
            set
            {
                bultos = value;
            }
        }
        public string Peso
        {
            get
            {
                return peso;
            }
            set
            {
                peso = value;
            }
        }
        public string Cod_tarifa
        {
            get
            {
                return cod_tarifa;
            }
            set
            {
                cod_tarifa = value;
            }
        }
        public string Reembolso
        {
            get
            {
                return reembolso;
            }
            set
            {
                reembolso = value;
            }
        }
        public string Retorno
        {
            get
            {
                return retorno;
            }
            set
            {
                retorno = value;
            }
        }
        public string Observaciones
        {
            get
            {
                return observaciones;
            }
            set
            {
                observaciones = value;
            }
        }
        public string Stock
        {
            get
            {
                return stock;
            }
            set
            {
                stock = value;
            }
        }
        public string Etiqueta
        {
            get
            {
                return etiqueta;
            }
            set
            {
                etiqueta = value;
            }
        }

        public string Servicio
        {
            get
            {
                return tipo_servicio;
            }
            set
            {
                tipo_servicio = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public void ConexionBd()
        {
            conn = new SqlCeConnection(@"Data Source = |DataDirectory|\BddPedidos.sdf");
            conn.Open();
        }

        public void DesconectarBd()
        {
            conn.Close();
        }

        public List<ConectarBD> ConsultarIdBd(string id)
        {
            List<ConectarBD> lista = new List<ConectarBD>();
            SqlCeCommand cmd = conn.CreateCommand();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "SELECT * FROM Pedidos WHERE Id = @id";

            SqlCeDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                ConectarBD datos = new ConectarBD();
                datos.Id = lector[0].ToString();
                datos.Num_pedido = lector[1].ToString();
                datos.Num_key = lector[2].ToString();
                datos.Ref_producto = lector[3].ToString();
                datos.Fecha_pedido = lector[4].ToString();
                datos.Destinatario = lector[5].ToString();
                datos.Direccion = lector[6].ToString();
                datos.Poblacion = lector[7].ToString();
                datos.Cod_postal = lector[8].ToString();
                datos.Telefono = lector[9].ToString();
                datos.Proveedor = lector[10].ToString();
                datos.Descripcion_producto = lector[11].ToString();
                datos.Bultos = lector[12].ToString();
                datos.Peso = lector[13].ToString();
                datos.Cod_tarifa = lector[14].ToString();
                datos.Reembolso = lector[15].ToString();
                datos.retorno = lector[16].ToString();
                datos.Observaciones = lector[17].ToString();
//***INI*** MOD 01/03/2018 ***INI***//
                //datos.Stock = lector[18].ToString();
                datos.Stock = lector[18].ToString();
                datos.Etiqueta = lector[19].ToString();
                datos.Servicio = lector[20].ToString();
              //  datos.listaServicios.Add(lector[20]);
//***FIN*** MOD 01/03/2018 ***FIN***//
//***INI*** MOD 21/11/2019 ***INI***//
                datos.Email = lector[21].ToString();
//***FIN*** MOD 21/11/2019 ***FIN***//



                lista.Add(datos);
            }
            return lista;
        }


        public void InsertarBd(string num_pedido, string num_key, string ref_producto, string fecha_pedido, string destinatario,
                        string direccion, string poblacion, string cod_postal, string telefono, string proveedor, string descripcion_producto,
                        string bultos, string peso, string cod_tarifa, string reembolso, string retorno, string observaciones, string stock, string etiquetas,
                        string tipo_servicio, string email)
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Pedidos ([num_pedido], [num_key], [ref_producto], [fecha_pedido], [destinatario], [direccion], [poblacion], [cod_postal], [telefono], [proveedor], [descripcion_producto], [bultos], [peso], [cod_tarifa], [reembolso], [retorno], [observaciones], [stock], [etiquetas], [tipo_servicio], [mail] ) VALUES ('" + num_pedido + "', '" + num_key + "', '" + ref_producto + "', '" + fecha_pedido + "', '" + destinatario + "', '" + direccion + "', '" + poblacion + "', '" + cod_postal + "', '" + telefono + "','" + proveedor + "', '" + descripcion_producto + "', '" + bultos + "', '" + peso + "', '" + cod_tarifa + "', '" + reembolso + "', '" + retorno + "', '" + observaciones + "', '" + stock + "', '" + "TH" + etiquetas + "', '" + tipo_servicio + "', '" + email + "')";
            cmd.ExecuteNonQuery();
        }

        public void UpdateBd(string id, string num_pedido, string num_key, string ref_producto, string destinatario, string direccion, string poblacion, string cod_postal, string telefono, string proveedor,
                             string descripcion_producto, string bultos, string peso, string cod_tarifa, string reembolso, string retorno, string observaciones, string stock, string etiquetas,
                             string tipo_servicio, string email)
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Pedidos SET num_pedido = '" + num_pedido + "',num_key = '" + num_key +"', ref_producto = '" + ref_producto + "', destinatario = '" + destinatario + "', direccion = '" + direccion + "', poblacion = '" + poblacion + "', cod_postal = '" + cod_postal + "', telefono = '" + telefono + "', proveedor = '" + proveedor + "', descripcion_producto = '" + descripcion_producto + "', bultos = '" + bultos + "', peso = '" + peso + "', cod_tarifa = '" + cod_tarifa + "', reembolso = '" + reembolso + "', retorno = '" + retorno + "', observaciones = '" + observaciones + "', etiquetas = '" + etiquetas + "', tipo_servicio = '" + tipo_servicio + "', mail = '" + email + "' WHERE Id = " + id;
            cmd.ExecuteNonQuery();
        }

        public void InsertarServicio(string servicio)
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Servicios ([IdServicios]) VALUES ('" + servicio + "')";
            cmd.ExecuteNonQuery();
        }

        public void UpdateServicioStockBd(string id, string tipo_servicio, string stock)
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Pedidos SET tipo_servicio = '" + tipo_servicio + "', stock = '" + stock + "' WHERE id = '" + id + "'";
            cmd.ExecuteNonQuery();
        }

        public void UpdateTipoServicioBd(string id, string tipo_servicio)
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Pedidos SET tipo_servicio = '" + tipo_servicio + "' WHERE id = '" + id + "'";
            cmd.ExecuteNonQuery();
        }

        public void UpdateStockBd(string id, string stock)
        {
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Pedidos SET stock = '" + stock + "' WHERE id = '" + id + "'";
            cmd.ExecuteNonQuery();
        }

        public void DeleteBd(string id)
        {
            SqlCeCommand cmd = conn.CreateCommand();

            cmd.CommandText = "DELETE FROM Pedidos WHERE id = '" + id + "'";

            cmd.ExecuteNonQuery();
        }

        public List<ConectarBD> CargarDatos()
        {
            List<ConectarBD> lista = new List<ConectarBD>();

            string consulta = "SELECT * FROM Pedidos Order by num_pedido";
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = consulta;
            SqlCeDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                ConectarBD datos = new ConectarBD();
                datos.Id = lector[0].ToString();
                datos.Num_pedido = lector[1].ToString();
                datos.Num_key = lector[2].ToString();
                datos.Ref_producto = lector[3].ToString();
                datos.Fecha_pedido = lector[4].ToString();
                datos.Destinatario = lector[5].ToString();
                datos.Direccion = lector[6].ToString();
                datos.Poblacion = lector[7].ToString();
                datos.Cod_postal = lector[8].ToString();
                datos.Telefono = lector[9].ToString();
                datos.Proveedor = lector[10].ToString();
                datos.Descripcion_producto = lector[11].ToString();
                datos.Bultos = lector[12].ToString();
                datos.Peso = lector[13].ToString();
                datos.Cod_tarifa = lector[14].ToString();
                datos.Reembolso = lector[15].ToString();
                datos.retorno = lector[16].ToString();
                datos.Observaciones = lector[17].ToString();
                datos.Stock = lector[18].ToString();
                datos.Etiqueta = lector[19].ToString();
                datos.tipo_servicio = lector[20].ToString();
                datos.Email = lector[21].ToString();

                lista.Add(datos);
            }

            return lista;
        }


        public List<ConectarBD> PedidosServicios()
        {
            List<ConectarBD> lista = new List<ConectarBD>();
            string consulta = "SELECT P.Id, P.num_pedido, P.num_key, P.ref_producto, P.fecha_pedido, P.destinatario, P.direccion, P.poblacion, P.cod_postal, P.telefono, P.proveedor, P.descripcion_producto, P.bultos, P.peso, P.cod_tarifa, P.reembolso, P.retorno, P.observaciones, P.stock, P.etiquetas, P.Email, S.IdServicios FROM Pedidos P inner join Servicios S on P.tipo_servicio = S.IdServicios Order by P.num_pedido";
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = consulta;
            SqlCeDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                ConectarBD datos = new ConectarBD();
                datos.Id = lector[0].ToString();
                datos.Num_pedido = lector[1].ToString();
                datos.Num_key = lector[2].ToString();
                datos.Ref_producto = lector[3].ToString();
                datos.Fecha_pedido = lector[4].ToString();
                datos.Destinatario = lector[5].ToString();
                datos.Direccion = lector[6].ToString();
                datos.Poblacion = lector[7].ToString();
                datos.Cod_postal = lector[8].ToString();
                datos.Telefono = lector[9].ToString();
                datos.Proveedor = lector[10].ToString();
                datos.Descripcion_producto = lector[11].ToString();
                datos.Bultos = lector[12].ToString();
                datos.Peso = lector[13].ToString();
                datos.Cod_tarifa = lector[14].ToString();
                datos.Reembolso = lector[15].ToString();
                datos.retorno = lector[16].ToString();
                datos.Observaciones = lector[17].ToString();
                datos.Stock = lector[18].ToString();
                datos.Etiqueta = lector[19].ToString();
                datos.tipo_servicio = lector[20].ToString();
                datos.Email = lector[21].ToString();

                lista.Add(datos);
            }

            return lista;
        }

        public List<ConectarBD> ConsultarIdMax()
        {
            List<ConectarBD> lista = new List<ConectarBD>();
            SqlCeCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT MAX(Id) FROM Pedidos";

            SqlCeDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                ConectarBD datos = new ConectarBD();
                datos.Id = lector[0].ToString();
                datos.Num_pedido = lector[1].ToString();
                datos.Num_key = lector[2].ToString();
                datos.Ref_producto = lector[3].ToString();
                datos.Fecha_pedido = lector[4].ToString();
                datos.Destinatario = lector[5].ToString();
                datos.Direccion = lector[6].ToString();
                datos.Poblacion = lector[7].ToString();
                datos.Cod_postal = lector[8].ToString();
                datos.Telefono = lector[9].ToString();
                datos.Proveedor = lector[10].ToString();
                datos.Descripcion_producto = lector[11].ToString();
                datos.Bultos = lector[12].ToString();
                datos.Peso = lector[13].ToString();
                datos.Cod_tarifa = lector[14].ToString();
                datos.Reembolso = lector[15].ToString();
                datos.retorno = lector[16].ToString();
                datos.Observaciones = lector[17].ToString();
                datos.Stock = lector[18].ToString();
                datos.Etiqueta = lector[19].ToString();
                datos.Email = lector[20].ToString();

                lista.Add(datos);
            }
            return lista;
        }
        /// <summary>
        /// Consultamos por nºpedido, proveedor y código de tarifa para ver si existe ya el artículo en la BBdd
        /// </summary>
        /// <returns></returns>
        public bool ConsultarArtProveedor(string numero_pedido, string proveedor, string codigo_tarifa)
        {
            List<ConectarBD> lista = new List<ConectarBD>();
            SqlCeCommand cmd = conn.CreateCommand();

            cmd.Parameters.AddWithValue("@numero_pedido", numero_pedido);
            cmd.Parameters.AddWithValue("@proveedor", proveedor);
            cmd.Parameters.AddWithValue("@codigo_tarifa", codigo_tarifa);
            cmd.CommandText = "SELECT * FROM Pedidos WHERE num_pedido = @numero_pedido AND proveedor = @proveedor AND cod_tarifa = @codigo_tarifa";

            SqlCeDataReader lector = cmd.ExecuteReader();

            return lector.Read();
        }
    }
    
}