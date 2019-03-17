using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Serialisers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public class MessageFilters : IQueryFilter
    {
        /// <summary>
        /// Retrieves only messages sent as part of the specified Campaign ID.
        /// </summary>
        [JsonProperty("Campaign")]
        public int? CampaignId { get; set; }

        /// <summary>
        /// Retrieves only messages sent to the specified Contact ID.
        /// </summary>
        [JsonProperty("Contact")]
        public int? ContactId { get; set; }

        /// <summary>
        /// Retrieves only messages tagged with the specified CustomID.
        /// </summary>
        [JsonProperty("CustomID")]
        public string CustomId { get; set; }

        /// <summary>
        /// Retrieves only messages sent from the specified Sender Email address.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Retrieves only messages sent from the specified sender domain.
        /// </summary>
        public string FromDomain { get; set; }

        /// <summary>
        /// Retrieves only messages sent from the sender address with the specified ID.
        /// </summary>
        [JsonProperty("FromID")]
        public string FromId { get; set; }

        /// <summary>
        /// Retrieves only messages sent after the specified timestamp.
        /// </summary>
        [JsonProperty("FromTs")]
        public DateTime? FromTimestamp { get; set; }

        /// <summary>
        /// Retrieves only messages of the specified type
        /// </summary>
        public EmailType? FromType { get; set; }

        /// <summary>
        /// Retrieves only messages sent before the specified timestamp.
        /// </summary>
        [JsonProperty("ToTs")]
        public DateTime? ToTimestamp { get; set; }

        /// <summary>
        /// Retrieve a list of objects starting from a certain offset. Combine this query parameter with Limit to retrieve a specific section of the list of objects. Defaults to 0.
        /// </summary>
        public int? Offset { get; set; }
        /// <summary>
        /// Limit the response to a select number of returned objects.
        /// Default value: 10. Maximum value: 1000
        /// </summary>
        public int? Limit { get; set; }

        [JsonProperty(nameof(CountOnly))]
        private int? countOnly { get; set; }

        [JsonIgnore]
        public bool CountOnly
        {
            get => countOnly == 1;
            set => countOnly = value ? 1 : 0;
        }

        public string CreateQueryParamsString()
        {
            var queryParams = CreateQueryParams();
            return string.Join("&", queryParams.Select(a => $"{a.Key}={a.Value}"));
        }

        public IEnumerable<KeyValuePair<string, string>> CreateQueryParams()
        {
            var jObject = MailjetSerialiser.Serialise(this).ToString();
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(jObject);
        }
    }
}
