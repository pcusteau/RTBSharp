using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RTBSharp.Models.BidResponseExtensionsViewModels;

namespace RTBSharp.Models.BidResponseViewModels
{

    public class BidResponse
    {
        public string id { get; set; }
        public SeatBid[] seatbid { get; set; }
        public string bidid { get; set; }
        public string cur { get; set; }
        public string customdata { get; set; }
        public int nbr { get; set; }
        public BidResponseExt ext { get; set; }

    }

    public class SeatBid
    {
        public Bid[] bid { get; set; }
        public string seat { get; set; }
        public int group { get; set; }
        public SeatBidExt ext { get; set; }
    }

    public class Bid
    {
        public string id { get; set; }
        public string impid { get; set; }
        public float price { get; set; }
        public string nurl { get; set; }
        public string burl { get; set; }
        public string lurl { get; set; }
        public string adm { get; set; }
        public string adid { get; set; }
        public string[] adomain { get; set; }
        public string bundle { get; set; }
        public string iurl { get; set; }
        public string cid { get; set; }
        public string crid { get; set; }
        public string tactic { get; set; }
        public string cat { get; set; }
        public int[] attr { get; set; }
        public int api { get; set; }
        public int protocol { get; set; }
        public string gagmediarating { get; set; }
        public string language { get; set; }
        public string dealid { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public int wratio { get; set; }
        public int exp { get; set; }
        public BidExt ext { get; set; }
    }



}
