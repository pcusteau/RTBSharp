using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using qSharp;
using RTBSharp.Models;
using static RTBSharp.Models.BidRequestViewModels;


namespace RTBSharp.Controllers
{
    [Route("OpenRTB25/[controller]/[action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly KdbConnectorOptions _kdbConnectorOptions;
        private readonly IConfiguration _configuration;

        // made this up - need to get the actual q dictionary specs
        private static readonly string[] BidRequestKeys = new String[] { "userID", "ip", "ua", "devcountry", "devregion", "devcity",
                                                                            "urls", "cat", "pubcat", "bidfloor", "w", "h",
                                                                            "id", "ssp", "json"};
        private static readonly string[] BidResponseKeys = new String[] { "time", "bid", "ad", "cid", "crid", "iurl",
                                                                            "w", "h", "adomain", "burl", "nurl", "language",
                                                                            "asid", "country", "advertiser", "agency", "duration", "cat"};


        public RequestController(
            ILogger<RequestController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _kdbConnectorOptions = new KdbConnectorOptions();
            configuration.GetSection(KdbConnectorOptions.KdbOptions).Bind(_kdbConnectorOptions);
        }


        // POST api/<RequestController>
        [HttpPost]
        public ActionResult Display([FromBody] BidRequest bidRequest)
        {
            //var bidRequest = JsonConvert.DeserializeObject<BidRequest>(content);

            // primary logic
            if (bidRequest is null || bidRequest.id is null || bidRequest.id == "")
            {
                return StatusCode(404);
            }

            // secondary logic 
            // this is where we may want to check on things like keywords, context, etc...


            if(_kdbConnectorOptions.TestMode)
            {
                // return test bid
                var bid = new Models.BidResponseViewModels.Bid()
                {
                    adomain = new string[] { "mrpfd.com" },
                    attr = new int[] { 1, 2, 3, 4, 5, 6, 7 },
                    cid = "campaign123",
                    crid = "creative123",
                    id = bidRequest.id,
                    impid = "102",
                    iurl = "https://adserver.com/winnotice?impid=102",
                    nurl = "https://adserver.com/pathtosampleimage",
                    price = 9.55f
                };

                var seatbid = new Models.BidResponseViewModels.SeatBid()
                {
                    bid = new Models.BidResponseViewModels.Bid[] { bid },
                    seat = "mrpfdseatid"
                };

                var response = new Models.BidResponseViewModels.BidResponse()
                {
                    bidid = "mrpfd1234567",
                    cur = "USD",
                    id = bidRequest.id,
                    seatbid = new Models.BidResponseViewModels.SeatBid[] { seatbid }
                };

                return new JsonResult(response);
            } else {


                // submit bid to kdb by passing a disctionary object
                // we're using the qsharp library, documentation here: https://github.com/exxeleron/qSharp/blob/master/doc/Readme.md
                // TO DO: Not sure the library does connection pooling and this sample will open connections to Kdb with every bid
                // need to see how to reuse existing connections, perhaps by creating connections at startup and passing via dependency injection


                var q = new QBasicConnection(
                        _kdbConnectorOptions.Host,
                        _kdbConnectorOptions.Port,
                        _kdbConnectorOptions.UserName,
                        _kdbConnectorOptions.Password,
                        _kdbConnectorOptions.Encoding
                    );

                try
                {
                    q.Open();


                    var qBidRequest = new QDictionary(BidRequestKeys, new Object[] { 
                    // marshal bid request into dictionary object

                    });

                    q.Sync("", qBidRequest);

                    var bid = new Models.BidResponseViewModels.Bid()
                    {
                        adomain = new string[] { "mrpfd.com" },
                        attr = new int[] { 1, 2, 3, 4, 5, 6, 7 },
                        cid = "campaign123",
                        crid = "creative123",
                        id = bidRequest.id,
                        impid = "102",
                        iurl = "https://adserver.com/winnotice?impid=102",
                        nurl = "https://adserver.com/pathtosampleimage",
                        price = 9.55f
                    };

                    var seatbid = new Models.BidResponseViewModels.SeatBid()
                    {
                        bid = new Models.BidResponseViewModels.Bid[] { bid },
                        seat = "mrpfdseatid"
                    };

                    var response = new Models.BidResponseViewModels.BidResponse()
                    {
                        bidid = "mrpfd1234567",
                        cur = "USD",
                        id = bidRequest.id,
                        seatbid = new Models.BidResponseViewModels.SeatBid[] { seatbid }
                    };

                    return new JsonResult(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine("`" + e.Message);
                    return StatusCode(404);
                }


            }

        }


    }
}
