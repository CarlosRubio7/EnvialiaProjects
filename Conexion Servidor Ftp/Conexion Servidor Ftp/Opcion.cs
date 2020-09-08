using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Conexion_Servidor_Ftp
{
    [XmlType("opcion")]
    public class Opcion
    {
        [XmlElement("nombre")]
        public String Nombre { get; set; }

        [XmlElement("valor")]
        public String Valor { get; set; }
    }
}
