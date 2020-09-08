using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Conexion_Servidor_Ftp
{
    public class Almacen
    {
        [XmlElement("direccion")]
        public String Direccion { get; set; }

        [XmlElement("ciudad")]
        public String Ciudad { get; set; }

        [XmlElement("cp")]
        public String Cp { get; set; }

        [XmlElement("provincia")]
        public String Provincia { get; set; }
    }
}
