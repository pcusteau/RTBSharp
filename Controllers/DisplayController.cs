using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RTBSharp.Models;
using static RTBSharp.Models.DisplayViewModels;


namespace RTBSharp.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display2Controller
        [HttpPost]
        public ActionResult Index([FromBody] string content)
        {

            var bidRequest = JsonConvert.DeserializeObject<BidRequest>(content);

            // primary logic
            if (bidRequest is null || bidRequest.id is null || bidRequest.id == "")
            {
                return StatusCode(404);
            }
        
            var bid = new Models.BidResponseViewModels.Bid()
            {
                adomain = new string[] {"mrpfd.com"},
                attr = new int[] {1,2,3,4,5,6,7},
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

            return Json(response);

        }
    }
}
