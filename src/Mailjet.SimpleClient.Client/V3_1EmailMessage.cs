using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mailjet.SimpleClient.Client
{
    internal class V3_1EmailMessage : IEmailMessage
    {
        public IEmailEntity From { get; set; }
        public IEnumerable<IEmailEntity> To { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IEnumerable<IEmailEntity> Cc { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IEnumerable<IEmailEntity> Bcc { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IDictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();

        [JsonProperty(PropertyName = "HTMLPart")]
        public string HtmlBody { get; set; }
        [JsonProperty(PropertyName = "TextPart")]
        public string PlainTextBody { get; set; }
        [JsonProperty(PropertyName = "TemplateLanguage")]
        public bool UseTemplateLanguage { get; set; }
    }
}
