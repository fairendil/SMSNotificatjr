using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SmsNotificator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSNotificationController : ControllerBase
    {
        // GET api/values
        [HttpGet("{text}")]
        public ActionResult<string> SendSMS(string text)
        {
            var parameters = new NameValueCollection {
                { "token", "az4mwwzjyeephpmwfom8kyk6u72dc1" },
                { "user", "ues8y1vvw4i24a34mtcnhnzaczpnui" },
                { "message", text }
            };

            using (var client = new WebClient())
            {
                client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
            }

            return text;
        }
    }
}
