using System;
namespace RTBSharp.Models
{
    public class LiveRampExtensionViewModels

    // this is not yet in the RTP2.5 spec but it is used by liveramp to pass in the IDL
    // you'll have to look for id where ext.rtiParner = "idl"
    // see specs here: https://github.com/Advertising-ID-Consortium/IdentityLink-in-RTB

    {
        public string source { get; set; }
        public uids uids { get; set; }    
    }

    public class uids
    {
        public string id { get; set; }
        public ext ext { get; set; }

    }

    public class ext
    {
        public string rtiPartner { get; set; }
    }
}