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

        public string host { get; set; }
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Encoding encoding { get; set; }
           
    }
}
