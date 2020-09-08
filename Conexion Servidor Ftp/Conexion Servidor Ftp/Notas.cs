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
            Nota = new List<String>();
        }

        [XmlArray("nota")]
        [XmlArrayItem("valor")]
        public List<String> Nota { get; set; }


    }
}
