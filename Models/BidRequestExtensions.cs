using System;
namespace RTBSharp.Models

    // these are extensions to the standard BidRequest objects
    // they often are specific to data vendors and SSPs so may need to be overriden
{
    public class BidRequestExtensions
    {
        public class ImpExt
        {

        }

        public class PmpExt
        {

        }

        public class BannerExt
        {

        }

        public class BidRequestExt
        {
            public string ssp { get; set; }
            public int at { get; set; }
            public Ads_Txt ads_txt { get; set; }
        }

        public class SourceExt
        {

        }

        public class RegExt
        {

        }

        public class MetricExt
        {

        }

        public class FormatExt
        {

        }

        public class DeviceExt
        {

        }

        public class AppExt
        {

        }

        public class ContentExt
        {

        }

        public class Ads_Txt
        {
            public int status { get; set; }
            public string auth_id { get; set; }
            public string pub_id { get; set; }
        }

        public class RestrictionsExt
        {
            public Addcat[] addcat { get; set; }
        }

        public class Addcat
        {
            public int cattax { get; set; }
            public string[] bcat { get; set; }
        }

        public class SiteExt
        {

        }

        public class UserDataExt
        {

        }

        public class SegmentExt
        {

        }

        public class UserExt
        {
            public string consent { get; set; }
            public Consented_Providers_Settings consented_providers_settings { get; set; }
            public object[] eids { get; set; }
        }

        public class Consented_Providers_Settings
        {
            public int[] consented_providers { get; set; }
        }

        public class GeoExt
        {

        }

        public class DealExt
        {

        }

        public class PublisherExt
        {

        }

        public class ProducerExt
        {

        }
    }
}
