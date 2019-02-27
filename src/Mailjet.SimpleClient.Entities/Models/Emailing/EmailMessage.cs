using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Emailing
{
    //TODO: JsonConstructor for deserialising (can't deserialise to interfaces)
    //TODO: Add plenty more properties, e.g. TemplateErrorReporting, Attachments, etc: https://dev.mailjet.com/guides/?csharp#send-api-json-properties
    public class EmailMessage : IEmailMessage
    {
        public EmailMessage(IEmailEntity from)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
        }
        public IEnumerable<IEmailEntity> To { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IEmailEntity From { get; set; }
        public IEnumerable<IEmailEntity> Cc { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IEnumerable<IEmailEntity> Bcc { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IDictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();

        [JsonProperty(PropertyName = "HtmlPart")]
        public string HtmlBody { get; set; }
        [JsonProperty(PropertyName = "TextPart")]
        public string PlainTextBody { get; set; }
        [JsonProperty(PropertyName = "TemplateLanguage")]
        public bool UseTemplateLanguage { get; set; }
        public string Id { get; set; }
        public string Subject { get; set; }
    }
}
