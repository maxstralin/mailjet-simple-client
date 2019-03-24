using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    /// <inheritdoc />
    public class MessageInformation : IMessageInformation
    {
        /// <inheritdoc />
        [JsonProperty("CampaignID")]
        public int CampaignId { get; set; }

        /// <inheritdoc />
        public int ClickTrackedCount { get; set; }

        /// <inheritdoc />
        [JsonProperty("ContactID")]
        public int ContactId { get; set; }

        /// <inheritdoc />
        public DateTime CreatedAt { get; set; }

        /// <inheritdoc />
        [JsonProperty("ID")]
        public long Id { get; set; }

        /// <inheritdoc />
        public int MessageSize { get; set; }

        /// <inheritdoc />
        public int OpenTrackedCount { get; set; }

        /// <inheritdoc />
        public int QueuedCount { get; set; }

        /// <inheritdoc />
        public DateTime SendEndAt { get; set; }

        /// <inheritdoc />
        public int SentCount { get; set; }

        //TODO 1.0: Awaiting documentation details from Mailjet
        /// <inheritdoc />
        public JToken SpamAssassinRules { get; set; }

        /// <inheritdoc />
        public int SpamAssassinScore { get; set; }
    }
}
