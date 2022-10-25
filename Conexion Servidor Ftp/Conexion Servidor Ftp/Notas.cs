using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Conexion_Servidor_Ftp
{
    [XmlType("notas")]
    public class Notas
    {
        public Notas()
        {

        }

        [XmlElement("tipo")]
        public String Tipo { get; set; }

        [XmlElement("valor")]
        public String Valor { get; set; }

    }
}

