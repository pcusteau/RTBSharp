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
        private readonly QBasicConnection _qConnection;

        public RequestController(
            ILogger<RequestController> logger,
            IConfiguration configuration,
            QBasicConnection qConnection)
        {
            _logger = logger;
            _configuration = configuration;
            _qConnection = qConnection;
            _kdbConnectorOptions = new KdbConnectorOptions();
            configuration.GetSection(KdbConnectorOptions.KdbOptions).Bind(_kdbConnectorOptions);
        }


        // POST api/<RequestController>
        [HttpPost]
        public ActionResult Display([FromBody] BidRequest bidRequest)
        {

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


                _logger.LogInformation("Bid received: {1}", JsonConvert.SerializeObject(bidRequest) );

                var qbidKeys = new List<String>();
                var qbidValues = new List<Object>();


                qbidKeys.Add("id");
                qbidValues.Add(bidRequest.id);

                qbidKeys.Add("time");
                qbidValues.Add(new QDateTime(DateTime.Now));


                qbidKeys.Add("ip");
                qbidValues.Add(bidRequest.device.ip);


                qbidKeys.Add("ua");
                qbidValues.Add(bidRequest.device.ua);


                qbidKeys.Add("urls");
                qbidValues.Add(bidRequest.site.page);


                qbidKeys.Add("ex");
                qbidValues.Add("TEST");


                qbidKeys.Add("UserID");
                qbidValues.Add(bidRequest.user.id);


                qbidKeys.Add("uid");
                qbidValues.Add(bidRequest.user.buyeruid);


                qbidKeys.Add("bidfloor");
                qbidValues.Add(bidRequest.imp.First().bidfloor);


                qbidKeys.Add("isTest");
                qbidValues.Add(_kdbConnectorOptions.TestMode);


                qbidKeys.Add("at");
                qbidValues.Add(bidRequest.at);


                qbidKeys.Add("w");
                qbidValues.Add(bidRequest.imp.First().banner.w);


                qbidKeys.Add("h");
                qbidValues.Add(bidRequest.imp.First().banner.h);


                qbidKeys.Add("cat");
                qbidValues.Add(bidRequest.site.cat.FirstOrDefault());


                qbidKeys.Add("devcountry");
                qbidValues.Add(bidRequest.device.geo.country);


                qbidKeys.Add("devregion");
                qbidValues.Add(bidRequest.device.geo.region);


                qbidKeys.Add("devcity");
                qbidValues.Add(bidRequest.device.geo.city);


                qbidKeys.Add("regsGDPR");
                qbidValues.Add("");


                qbidKeys.Add("iabGDPR");
                qbidValues.Add("");


                qbidKeys.Add("consentedVendors");
                qbidValues.Add("");


                qbidKeys.Add("json");
                qbidValues.Add(JsonConvert.SerializeObject(bidRequest));
                

                try
                {

                    // check if connection is lost need to reconnect
                    if(!_qConnection.IsConnected())
                    {
                        _qConnection.Reset();
                        _logger.LogInformation("Connection to kdb was reset");
                    }

                    var qBidResponse = (QDictionary)_qConnection.Sync(".dmc_bidder.upd_bidRequest", new QDictionary(qbidKeys.ToArray(), qbidValues.ToArray()));


                    // marshall values back into bidResponse

                    var bid = new Models.BidResponseViewModels.Bid() { };
                    var seat = "";

                    foreach (var kvp in qBidResponse)
                    {

                        switch(kvp.Key)
                        {
                            case "w":
                                bid.w = (Int16)kvp.Value;
                                break;
                            case "h":
                                bid.h = (Int16)kvp.Value;
                                break;
                            case "bid":
                                bid.price = Convert.ToSingle((Double)kvp.Value);
                                break;
                            case "ad":
                                bid.adm = new string((char[])kvp.Value);
                                break;
                            case "cid":
                                bid.cid = new string((char[])kvp.Value);
                                break;
                            case "burl":
                                bid.nurl = new string((char[])kvp.Value);
                                break;
                            case "crid":
                                bid.crid = new string((char[])kvp.Value);
                                break;
                            case "iurl":
                                bid.iurl = new string((char[])kvp.Value);
                                break;
                            case "adomain":
                                bid.adomain = new string[] { new string((char[])kvp.Value) };
                                break;
                            case "seat":
                                seat = new string((char[])kvp.Value);
                                break;
                            default:
                                break;
                        };
                    }

                    
                    var seatbid = new Models.BidResponseViewModels.SeatBid()
                    {
                        bid = new Models.BidResponseViewModels.Bid[] { bid },
                        seat = seat
                    };

                    var response = new Models.BidResponseViewModels.BidResponse()
                    {
                        bidid = "mrpfd1234567",
                        cur = "USD",
                        id = bidRequest.id,
                        seatbid = new Models.BidResponseViewModels.SeatBid[] { seatbid }
                    };

                    _logger.LogInformation("Bid response: {1}", JsonConvert.SerializeObject(response));

                    return new JsonResult(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine("`" + e.Message);
                    if(e.Source == "System.Net.Sockets" && e.HResult == -2146232798)
                    {
                        // possibly lost connexion to socket - may want to try and reconnect
                        try
                        {
                            _logger.LogInformation("Attempting to reset connection to kdb");
                            _qConnection.Reset();
                            _logger.LogInformation("Connection to kdb was reset");
                        }
                        catch (Exception ex)
                        {
                            _logger.LogCritical("Could not re-establish connection to kdb");
                            // well if this doesn't work....
                        }
                    }
                    _logger.LogCritical("Feedhandler error: {1}", e.Message);
                    return StatusCode(404);
                }


            }

        }


    }
}
