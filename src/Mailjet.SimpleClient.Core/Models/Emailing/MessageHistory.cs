using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public class MessageHistory : IMessageHistory
    {
        /// <inheritdoc />
        public string Comment { get; set; }

        /// <inheritdoc />
        [JsonIgnore]
        public DateTime EventStamp => DateTimeOffset.FromUnixTimeSeconds(EventAt).UtcDateTime;

        public long EventAt { get; set; }

        /// <inheritdoc />
        public EventType EventType { get; set; }

        /// <inheritdoc />
        [JsonProperty("State")]
        public string NonDeliveryReason { get; set; }

        /// <inheritdoc />
        [JsonProperty("Useragent")]
        public string UserAgent { get; set; }

        /// <inheritdoc />
        [JsonProperty("UseragentID")]
        public int UserAgentId { get; set; }
    }
}
