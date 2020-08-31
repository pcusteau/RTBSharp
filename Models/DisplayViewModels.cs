using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTBSharp.Models
{
    public class DisplayViewModels
    {

        public class BidRequest
        {
            public string id { get; set; }
            public int tmax { get; set; }
            public int at { get; set; }
            public string[] seat { get; set; }
            public Ext ext { get; set; }
            public string[] cur { get; set; }
            public Source source { get; set; }
            public int package { get; set; }
            public Item[] item { get; set; }
            public Context context { get; set; }
        }

        public class Ext
        {
            public string ssp { get; set; }
            public int at { get; set; }
            public Ads_Txt ads_txt { get; set; }
        }

        public class Ads_Txt
        {
            public int status { get; set; }
            public string auth_id { get; set; }
            public string pub_id { get; set; }
        }

        public class Source
        {
            public string tid { get; set; }
            public long ts { get; set; }
            public string ds { get; set; }
        }

        public class Context
        {
            public Regs regs { get; set; }
            public Restrictions restrictions { get; set; }
            public Site site { get; set; }
            public User user { get; set; }
            public Device device { get; set; }
        }

        public class Regs
        {
            public int gdpr { get; set; }
            public int coppa { get; set; }
        }

        public class Restrictions
        {
            public int cattax { get; set; }
            public string[] bcat { get; set; }
            public Ext1 ext { get; set; }
            public string[] badv { get; set; }
        }

        public class Ext1
        {
            public Addcat[] addcat { get; set; }
        }

        public class Addcat
        {
            public int cattax { get; set; }
            public string[] bcat { get; set; }
        }

        public class Site
        {
            public string id { get; set; }
            public string name { get; set; }
            public string domain { get; set; }
            public int mobile { get; set; }
            public int amp { get; set; }
            public Pub pub { get; set; }
        }

        public class Pub
        {
            public string id { get; set; }
            public string name { get; set; }
            public string domain { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string consent { get; set; }
            public string buyeruid { get; set; }
            public int yob { get; set; }
            public string gender { get; set; }
            public Ext2 ext { get; set; }
        }

        public class Ext2
        {
            public string consent { get; set; }
            public Consented_Providers_Settings consented_providers_settings { get; set; }
            public object[] eids { get; set; }
        }

        public class Consented_Providers_Settings
        {
            public int[] consented_providers { get; set; }
        }

        public class Device
        {
            public int type { get; set; }
            public string ifa { get; set; }
            public string ip { get; set; }
            public string ua { get; set; }
            public string make { get; set; }
            public string model { get; set; }
            public string hwv { get; set; }
            public int os { get; set; }
            public string osv { get; set; }
            public string mccmnc { get; set; }
            public Geo geo { get; set; }
        }

        public class Geo
        {
            public int type { get; set; }
            public float lat { get; set; }
            public float lon { get; set; }
            public string country { get; set; }
            public int utcoffset { get; set; }
        }

        public class Item
        {
            public string id { get; set; }
            public Metric metric { get; set; }
            public int qty { get; set; }
            public int _private { get; set; }
            public Deal[] deal { get; set; }
            public Spec spec { get; set; }
        }

        public class Metric
        {
            public string type { get; set; }
            public string vendor { get; set; }
            public float value { get; set; }
        }

        public class Spec
        {
            public Placement placement { get; set; }
        }

        public class Placement
        {
            public string tagid { get; set; }
            public int curlx { get; set; }
            public int secure { get; set; }
            public Display display { get; set; }
        }

        public class Display
        {
            public int[] ctype { get; set; }
            public int ampren { get; set; }
            public int instl { get; set; }
            public Displayfmt[] displayfmt { get; set; }
            public Event[] _event { get; set; }
        }

        public class Displayfmt
        {
            public int w { get; set; }
            public int h { get; set; }
        }

        public class Event
        {
            public int type { get; set; }
            public int[] method { get; set; }
        }

        public class Deal
        {
            public string id { get; set; }
            public float flr { get; set; }
        }

    }
}
