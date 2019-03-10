using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Converters;
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
        public long CreationTs { get; set; }
        public DateTime CreationTimestamp => DateTimeOffset.FromUnixTimeSeconds(CreationTs).UtcDateTime;

        [JsonProperty("SentTS")]
        public long SentTs { get; set; }

        public DateTime SentTimestamp => DateTimeOffset.FromUnixTimeSeconds(SentTs).UtcDateTime;

        [JsonConverter(typeof(InterfaceJsonConverter<SendSmsCost>))]
        public ISendSmsCost Cost { get; set; }
        [JsonConverter(typeof(InterfaceJsonConverter<SendSmsStatus>))]
        public ISendSmsStatus Status { get; set; }
    }
}
