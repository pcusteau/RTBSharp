using Newtonsoft.Json;
using static RTBSharp.Models.BidRequestExtensionsViewModels;

namespace RTBSharp.Models
{
    public class BidRequestViewModels
    // this is based on OpenRTB specs 2.5 found here: https://www.iab.com/wp-content/uploads/2016/03/OpenRTB-API-Specification-Version-2-5-FINAL.pdf
    {

        public class BidRequest
        {
            public string id { get; set; }
            public Imp[] imp { get; set; }
            public Site site { get; set; }
            public App app { get; set; }
            public Device device { get; set; }
            public User user { get; set; }
            public int test { get; set;}
            public int at { get; set; }
            public int tmax { get; set; }
            public string[] wseat { get; set; }
            public string[] bseat { get; set; }
            public int allimps { get; set; }
            public string[] cur { get; set; }
            public string[] wlang { get; set; }
            public string[] bcat { get; set; }
            public string[] badv { get; set; }
            public string[] bapp { get; set; }
            public Source source { get; set; }
            public Regs regs { get; set; }
            public BidRequestExt ext { get; set; }
        }

        public class Source
        {
            public int fd { get; set; }
            public string tid { get; set; }
            public string pchain { get; set; }
            public SourceExt ext { get; set; }
        }

        public class Regs
        {
            public int gdpr { get; set; }
            public int coppa { get; set; }
            public RegExt ext { get; set; }
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

        public class Metric
        {
            public string type { get; set; }
            public float value { get; set; }
            public string vendor { get; set; }
            public MetricExt ext { get; set; }
        }

        public class Banner
        {
            public Format[] format { get; set; }
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

        public class Format
        {
            public int w { get; set; }
            public int h { get; set; }
            public int wratio { get; set; }
            public int hratio { get; set; }
            public int wmin { get; set; }
            public FormatExt ext {get; set; }
        }

        public class Pmp
        {
            public int private_auction { get; set; }
            public Deal[] deals { get; set; }
            public PmpExt ext { get; set; }
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
            public string keywords { get; set; }
            public SiteExt ext { get; set; }
        }

        public class App
        {
            public string id { get; set; }
            public string name { get; set; }
            public string bundle { get; set; }
            public string domain { get; set; }
            public string storeurl { get; set; }
            public string[] cat { get; set; }
            public string[] sectioncat { get; set; }
            public string[] pagecat { get; set; }
            public string ver { get; set; }
            public int privacypolicy { get; set; }
            public int paid { get; set; }
            public Publisher publisher { get; set; }
            public Content content { get; set; }
            public string keywords { get; set; }
            public AppExt ext { get; set; }
        }

        public class Publisher
        {
            public string id { get; set; }
            public string name { get; set; }
            public string[] cat { get; set; }
            public string domain { get; set; }
            public PublisherExt ext { get; set; }
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
            public int prodq { get; set; }
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
            public Data data { get; set; }
            public ContentExt ext { get; set; }
        }

        public class Producer
        {
            public string id { get; set; }
            public string[] cat { get; set; }
            public string domain { get; set; }
            public ProducerExt ext { get; set; }
        }

        public class Device
        {
            public string ua { get; set; }
            public Geo geo { get; set; }
            public int dnt { get; set; }
            public int lmt { get; set; }
            public string ip { get; set; }
            public string ipv6 { get; set; }
            public int devicetype { get; set; }
            public string make { get; set; }
            public string model { get; set; }
            public string os { get; set; }
            public string osv { get; set; }
            public string hwv { get; set; }
            public int h { get; set; }
            public int w { get; set; }
            public int ppi { get; set; }
            public float pxratio { get; set; }
            public int js { get; set; }
            public int geofetch { get; set; }
            public string flashver { get; set; }
            public string language { get; set; }
            public string carrier { get; set; }
            public string mccmnc { get; set; }
            public int connectiontype { get; set; }
            public string ifa { get; set; }
            public string didsha1 { get; set; }
            public string didmd5 { get; set; }
            public string macsha1 { get; set; }
            public string macmd5 { get; set; }
            public int type { get; set; }
            public DeviceExt ext { get; set; }

        }

        public class Geo
        {
            public float lat { get; set; }
            public float lon { get; set; }
            public int type { get; set; }
            public int accuracy { get; set; }
            public int lastfix { get; set; }
            public int ipservice { get; set; }
            public string country { get; set; }
            public string region { get; set; }
            public string regionfips104 { get; set; }
            public string metro { get; set; }
            public string city { get; set; }
            public string zip { get; set; }
            public int utcoffset { get; set; }
            public GeoExt ext { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string buyerid { get; set; }
            public string consent { get; set; }
            public string buyeruid { get; set; }
            public int yob { get; set; }
            public string gender { get; set; }
            public string keywords { get; set; }
            public string customdata { get; set; }
            public Geo geo { get; set; }
            public Data data { get; set; }
            public UserExt ext { get; set; }
        }

        public class Data
        {
            public string id { get; set; }
            public string name { get; set; }
            public Segment segment { get; set; }
            public UserDataExt ext { get; set; }
        }

        public class Segment
        {
            public string id { get; set; }
            public string name { get; set; }
            public string value { get; set; }
            public SegmentExt ext { get; set; }
        }

    }


}
