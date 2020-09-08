using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Uptook
{
    [XmlType("retorno")]
    public class Retorno
    {
        public Retorno()
        {
            Productos = new List<Producto>();
        }

        [XmlElement("proveedor")]
        public String Proveedor { get; set; }

        [XmlElement("almacen")]
        public Almacen Almacen { get; set; }

        [XmlElement("fecha")]
        public String Fecha { get; set; }

        [XmlElement("numero")]
        public String Numero { get; set; }

        [XmlElement("referencia")]
        public String Referencia { get; set; }

        [XmlArray("productos")]
        [XmlArrayItem("producto")]
        public List<Producto> Productos { get; set; }
    }
}
