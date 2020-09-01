using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTBSharp.Models
{
    public class KdbConnectorOptions
    {
        // These are settings for the kdb connection - set in appsettings.json file
        //String host, int port, String username, String password, String encoding

        public const string KdbOptions = "KdbOptions";

        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Encoding Encoding { get; set; }
        public bool TestMode { get; set; }
           
    }
}
