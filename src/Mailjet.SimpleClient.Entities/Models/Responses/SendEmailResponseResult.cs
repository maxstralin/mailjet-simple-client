using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Responses
{
    public class SendEmailResponseResult
    {
        public string Email { get; set; }
        [JsonProperty(PropertyName = "MessageUUID")]
        public string MessageUuid { get; set; }
        [JsonProperty(PropertyName = "MessageID")]
        public long MessageId { get; set; }
        public string MessageHref { get; set; }
    }
}
