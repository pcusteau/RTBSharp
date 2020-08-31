using Newtonsoft.Json;

namespace RTBSharp.Models
{
    public class BidRequestViewModels
    // this is based on OpenRTB specs 2.5 found here: https://www.iab.com/wp-content/uploads/2016/03/OpenRTB-API-Specification-Version-2-5-FINAL.pdf
    {

        public class BidRequest
        {
            public string id { get; set; }
            public Imp imp { get; set; }
            public int tmax { get; set; }
            public int at { get; set; }
            public string[] seat { get; set; }
            public BidRequestExt ext { get; set; }
            public string[] cur { get; set; }
            public Source source { get; set; }
            public int package { get; set; }
            public Item[] item { get; set; }
            public Context context { get; set; }
        }

        public class Imp
        {
            public string id { get; set; }
            public Metric metric { get; set; }
            public Banner banner { get; set; }
            public Video video { get; set; }
            public Audio audio { get; set; }
            public Native native { get; set; }
            public Pmp pmp { get; set; }
            public string displaymanager { get; set; }
            public string displaymanagerver { get; set; }
            public int instl { get; set; }
            public string tagid { get; set; }
            public float bidfloor { get; set; }
            public string bidfloorcur { get; set; }
            public int clickbrowser { get; set; }
            public int secure { get; set; }
            public string[] iframebuster { get; set; }
            public int exp { get; set; }
            public ImpExt ext { get; set; }
        }

        public class Banner
        {
            public format[] format { get; set; }
            public int w { get; set; }
            public int h { get; set; }
            public int[] btype { get; set; }
            public int[] battr { get; set; }
            public int pos { get; set; }
            public string[] mimes { get; set; }
            public int topframe { get; set; }
            public int[] expdir { get; set; }
            public int[] api { get; set; }
            public string id { get; set; }
            public int vcm { get; set; }
            public BannerExt ext { get; set; }

        }

        public class Video
        {

        }

        public class Audio
        {

        }

        public class Native
        {

        }

        public class Pmp
        {
            public int private_auction { get; set; }
            public Deal[] deals { get; set; }
            public PmpExt ext { get; set; }
        }

        public class ImpExt
        {

        }

        public class PmpExt
        {

        }

        public class format
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
            public RestrictionsExt ext { get; set; }
            public string[] badv { get; set; }
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

        public class Site
        {
            public string id { get; set; }
            public string name { get; set; }
            public string domain { get; set; }
            public string[] cat { get; set; }
            public string[] sectioncat { get; set; }
            public string[] pagecat { get; set; }
            public string page { get; set; }
            [JsonProperty("ref")]
            public string @ref { get; set; }
            public string search { get; set; }
            public int mobile { get; set; }
            public int privacypolicy { get; set; }
            public Publisher publisher { get; set; }
            public Content content { get; set; }
            public int amp { get; set; }
            public Pub pub { get; set; }
            public string keywords { get; set; }
            public SiteExt ext { get; set; }
        }

        public class SiteExt
        {

        }

        public class Content
        {
            public string id { get; set; }
            public int episode { get; set; }
            public string title { get; set; }
            public string series { get; set; }
            public string season { get; set; }
            public string artist { get; set; }
            public string genre { get; set; }
            public string album { get; set; }
            public string isrc { get; set; }
            public Producer producer { get; set; }
            public string url { get; set; }
            public string[] cat { get; set; }
            public int prodq { get; set;}
            public int context { get; set; }
            public string contentrating { get; set; }
            public string userrating { get; set; }
            public int qagmediarating { get; set; }
            public string keywords { get; set; }
            public int livestream { get; set; }
            public int sourcerelationship { get; set; }
            public int len { get; set; }
            public string language { get; set; }
            public int embeddable { get; set; }
            public ContentData data { get; set; }
            public ContentExt ext { get; set; }
        }


        public class ContentExt
        {

        }

        public class ContentData
        {

        }


        public class Producer
        {
            public string id { get; set; }
            public string[] cat { get; set; }
            public string domain { get; set; }
            public ProducerExt ext { get; set; }
        }

        public class ProducerExt
        {

        }

        public class Pub
        {
            public string id { get; set; }
            public string name { get; set; }
            public string domain { get; set; }
        }

        public class Publisher
        {
            public string id { get; set; }
            public string name { get; set; }
            public string[] cat { get; set; }
            public string domain { get; set; }
            public PublisherExt ext { get; set; }
        }

        public class PublisherExt
        {

        }

        public class Content
        {

        }

        public class User
        {
            public string id { get; set; }
            public string consent { get; set; }
            public string buyeruid { get; set; }
            public int yob { get; set; }
            public string gender { get; set; }
            public UserExt ext { get; set; }
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
            public float bidfloor { get; set; }
            public string bidfloorcur { get; set; }
            public int at { get; set; }
            public float flr { get; set; }
            public string[] wseat { get; set; }
            public string[] wadomain { get; set; }
            public DealExt ext { get; set; }
        }

        public class DealExt
        {

        }

        public class App
        {

        }

    }

    
}
