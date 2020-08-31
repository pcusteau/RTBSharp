using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using qSharp;
using RTBSharp.Models;
using static RTBSharp.Models.DisplayViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RTBSharp.Controllers
{
    [Route("OpenRTB25/[controller]/[action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly KdbConnectorOptions _kdbConnectorOptions;
        // made this up - need to get the actual q dictionary specs
        private static readonly string[] BidRequestKeys = new String[] { "id", "tmax", "at", "seat", "ext", "cur", "source", "ip" };

        public RequestController(
            ILogger<RequestController> logger,
            IOptions<KdbConnectorOptions> kdbConnectorOptions)
        {
            _logger = logger;
            _kdbConnectorOptions = kdbConnectorOptions.Value;
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


            // submit bid to kdb by passing a disctionary object
            // we're using the qsharp library, documentation here: https://github.com/exxeleron/qSharp/blob/master/doc/Readme.md
            // TO DO: This sample will open connections to Kdb with ever bid
            // need to see how to reuse existing connections, perhaps by creating connection at startup and passing via dependency injection
            
            
            //var q = new QBasicConnection(
            //        _kdbConnectorOptions.host,
            //        _kdbConnectorOptions.port,
            //        _kdbConnectorOptions.username,
            //        _kdbConnectorOptions.password,
            //        _kdbConnectorOptions.encoding
            //    );

            //try
            //{
            //    q.Open();
                
                
            //    var qBidRequest = new QDictionary(BidRequestKeys, new Object[] { 
            //    // marshal bid request into dictionary object
                
            //    });

            //    q.Sync("", qBidRequest);


            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("`" + e.Message);
            //}
            //finally
            //{
            //    q.Close();
            //}



            // return bid
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

            var seatbid = new Models.BidResponseViewModels.Seatbid()
            {
                bid = new Models.BidResponseViewModels.Bid[] { bid },
                seat = "mrpfdseatid"
            };

            var response = new Models.BidResponseViewModels.Response()
            {
                bidid = "mrpfd1234567",
                cur = "USD",
                id = bidRequest.id,
                seatbid = new Models.BidResponseViewModels.Seatbid[] { seatbid }
            };

            return new JsonResult(response);
        }


    }
}
