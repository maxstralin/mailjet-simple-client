using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Sms;
using Newtonsoft.Json;

namespace Mailjet.SimpleClient.Core.Models.Responses.Sms
{
    public class SendSmsStatus : ISendSmsStatus
    {
        [JsonProperty("Code")]
        public SmsStatus SmsStatus { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
