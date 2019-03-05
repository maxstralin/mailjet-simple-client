using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json;

namespace Mailjet.SimpleClient.Core.Models.Responses.Sms
{
    public class SendSmsResponseEntry : ISendSmsResponseEntry
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        [JsonProperty("MessageID")]
        public int MessageId { get; set; }

        [JsonProperty("SMSCount")]
        public int SmsCount { get; set; }
        [JsonProperty("CreationTS")]
        public long CreationTimestamp { get; set; }
        [JsonProperty("SentTS")]
        public long SentTimestamp { get; set; }
    }
}
