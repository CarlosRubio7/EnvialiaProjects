using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uptook
{
    public class FtpSettings
    {
        public int Port { get; set; }
        public string Server { get; set; }
        public string RemoteFolderPath { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
