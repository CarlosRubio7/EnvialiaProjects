using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Conexion_Servidor_Ftp
{
    [XmlType("bulto")]
    public class Bulto
    {
        [XmlElement("numero")]
        public String Numero { get; set; }

        [XmlElement("volumen")]
        public String Volumen { get; set; }

        [XmlElement("peso")]
        public String Peso { get; set; }

        [XmlElement("etiqueta")]
        public String Etiqueta { get; set; }

        [XmlElement("referencia")]
        public String Referencia { get; set; }

        [XmlElement("descripcion")]
        public String Descripcion { get; set; }

        [XmlElement("agencia")]
        public String Agencia { get; set; }

        [XmlElement("codigo_agencia")]
        public String CodigoAgencia { get; set; }
    }
}
