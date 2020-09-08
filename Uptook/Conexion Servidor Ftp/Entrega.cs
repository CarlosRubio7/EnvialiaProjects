using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Uptook
{
    public class Entrega
    {
        public Entrega()
        {
            Telefonos = new List<String>();
        }

        [XmlElement("nombre")]
        public String Nombre { get; set; }

        [XmlElement("direccion")]
        public String Direccion { get; set; }

        [XmlElement("ciudad")]
        public String Ciudad { get; set; }

        [XmlElement("cp")]
        public String Cp { get; set; }

        [XmlElement("provincia")]
        public String Provincia { get; set; }

        [XmlElement("pais")]
        public String Pais { get; set; }

        [XmlElement("empresa")]
        public String Empresa { get; set; }

        [XmlElement("email")]
        public String Email { get; set; }

        [XmlArray("telefonos")]
        [XmlArrayItem("telefono")]
        public List<String> Telefonos { get; set; }
    } 
}
