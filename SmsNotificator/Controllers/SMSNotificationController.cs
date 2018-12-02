using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace SmsNotificator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSNotificationController : ControllerBase
    {
        private readonly IOptions<PushoverTokens> config;

        public SMSNotificationController(IOptions<PushoverTokens> config)
        {
            this.config = config;
        }
        // GET api/values
        [HttpGet("{text}")]
        public ActionResult<string> SendSMS(string text)
        {
            
            var parameters = new NameValueCollection {
                { "token", config.Value.AppToken },
                { "user", config.Value.UserKey },
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
