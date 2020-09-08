using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Uptook
{
    [XmlType("producto")]
    public class Producto
    {
        public Producto()
        {
            Opciones = new List<Opcion>();
            Bultos = new List<Bulto>();
        }

        [XmlElement("nombre")]
        public String Nombre { get; set; }

        [XmlElement("unidades")]
        public String Unidades { get; set; }

        [XmlElement("referencia")]
        public String Referencia { get; set; }

        [XmlArray("opciones")]
        [XmlArrayItem("opcion")]
        public List<Opcion> Opciones { get; set; }

        [XmlArray("bultos")]
        [XmlArrayItem("bulto")]
        public List<Bulto> Bultos { get; set; }
    }
}
