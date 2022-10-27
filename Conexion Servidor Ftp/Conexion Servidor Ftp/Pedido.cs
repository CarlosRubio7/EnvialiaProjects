using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Conexion_Servidor_Ftp
{
    [XmlType("pedido")]
    public class Pedido
    {
        public Pedido()
        {
            Recogidas = new List<Recogida>();
        }

        [XmlArray("recogidas")]
        [XmlArrayItem("recogida")]
        public List<Recogida> Recogidas { get; set; }

        [XmlArray("retornos")]
        [XmlArrayItem("retorno")]
        public List<Retorno> Retornos { get; set; }

        [XmlElement("numero")]
        public String Numero { get; set; }

        [XmlElement("referencia")]
        public String Referencia { get; set; }

        [XmlElement("fecha")]
        public String Fecha { get; set; }

        [XmlElement("entrega")]
        public Entrega Entrega { get; set; }

        [XmlArray("notas")]
        [XmlArrayItem("nota")]
        public List<Notas> Notas { get; set; }

        public List<LineaPedido> getLineasPedido()
        {
            List<LineaPedido> lineasPedido = new List<LineaPedido>();
            LineaPedido lineaPedido = null;
            Notas n = new Notas();

            if (Notas.Count == 0)
            {
                n.Valor = "0";
                n.Tipo = "";
            }
            else
            {
                n.Valor = Notas[0].Valor;
                n.Tipo = Notas[0].Tipo;
            }

            foreach (Recogida recogida in Recogidas)
            {
                foreach (Producto producto in recogida.Productos)
                {
                    foreach (Bulto bulto in producto.Bultos)
                    {
                        if (Retornos.Count == 0)
                        {
                            lineaPedido = new LineaPedido(Numero, Referencia, Fecha, Entrega, recogida.Proveedor, bulto, n, "0");

                            lineasPedido.Add(lineaPedido);
                        }
                        else
                        {
                            lineaPedido = new LineaPedido(Numero, Referencia, Fecha, Entrega, recogida.Proveedor, bulto, n, "1");

                            lineasPedido.Add(lineaPedido);

                        }
                    }
                }
            }
            return lineasPedido;
        }
    }
}
