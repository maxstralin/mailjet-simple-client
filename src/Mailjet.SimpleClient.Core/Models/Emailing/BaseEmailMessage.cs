using System;
using System.Collections.Generic;
using System.Linq;
using Mailjet.SimpleClient.Core.Converters;
using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public abstract class BaseEmailMessage : IEmailMessage
    {
        /// <inheritdoc />
        public IEnumerable<IEmailEntity> To { get; set; } = Enumerable.Empty<IEmailEntity>();

        /// <inheritdoc />
        public IEmailEntity From { get; set; }

        /// <inheritdoc />
        public IEnumerable<IEmailEntity> Cc { get; set; } = Enumerable.Empty<IEmailEntity>();

        /// <inheritdoc />
        public IEnumerable<IEmailEntity> Bcc { get; set; } = Enumerable.Empty<IEmailEntity>();
        /// <inheritdoc />
        public string Subject { get; set; }

        /// <summary>
        /// Variables used in template language
        /// </summary>
        public IDictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// If template language should be enabled, defaults to false.
        /// </summary>
        [JsonProperty(PropertyName = "TemplateLanguage")]
        public bool UseTemplateLanguage { get; set; } = false;

        /// <summary>
        /// Add your own ID to the message
        /// </summary>
        [JsonProperty(PropertyName = "CustomID")]
        public string CustomId { get; set; }

        /// <summary>
        /// Used to enrich the message with custom data, which can be of any format (XML, JSON, CSV, etc).
        /// </summary>
        public string EventPayload { get; set; }

        /// <summary>
        /// If there's a template language error, send information to this email entity.
        /// </summary>
        [JsonProperty(PropertyName = "TemplateErrorReporting")]
        public IEmailEntity ReportTemplateErrorTo { get; set; }

        /// <summary>
        /// If template language errors should be reported. If true, will send the error to <see cref="ReportTemplateErrorTo"/>
        /// </summary>
        [JsonProperty(PropertyName = "TemplateErrorDeliver")]
        public bool? SendTemplateErrors { get; set; }

        /// <summary>
        /// Groups multiple messages in one campaign
        /// </summary>
        public string CustomCampaign { get; set; }

        /// <summary>
        /// Block/unblock messages to be sent multiple times inside one campaign to the same contact. False = unblocked (default), true = blocked.
        /// Can only be used if CustomCampaign is specified.
        /// </summary>
        public bool DeduplicateCampaign { get; set; } = false;

        [JsonProperty(PropertyName = "URLTags")]
        private string urlTags
        {
            get
            {
                if (UrlTags == null) return null;
                var values = UrlTags.ToList();
                if (values.Count == 0) return null;

                return string.Join("&", UrlTags.Select(a => $"{a.Key}={a.Value}"));
            }
        }

        /// <summary>
        /// URL parameters to append to all your URLs. A maximum length of 256 characters is allowed per message. The properties will be escaped before sending.
        /// </summary>
        [JsonIgnore] public IEnumerable<KeyValuePair<string, string>> UrlTags;

        /// <summary>
        /// Monitoring category for real time monitoring
        /// </summary>
        public string MonitoringCategory { get; set; }

        /// <summary>
        /// Email priority queue, see comments on each value for more information
        /// </summary>
        public EmailPriority? Priority { get; set; }

        public TrackingMode? TrackClicks { get; set; }
        public TrackingMode? TrackOpens { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Headers { get; set; }

        public IEnumerable<IAttachment> Attachments { get; set; }
        public IEnumerable<IInlinedAttachment> InlinedAttachments { get; set; }

    }
}
