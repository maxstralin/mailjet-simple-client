using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Responses
{
    public class SendEmailResponseResult : ISendEmailResponseResult
    {
        public string Email { get; set; }
        [JsonProperty(PropertyName = "MessageUUID")]
        public string MessageUuid { get; set; }
        [JsonProperty(PropertyName = "MessageID")]
        public long MessageId { get; set; }
        public string MessageHref { get; set; }
    }
}
