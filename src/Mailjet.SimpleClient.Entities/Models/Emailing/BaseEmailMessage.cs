using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Emailing
{
    public abstract class BaseEmailMessage : IEmailMessage
    {
        public IEnumerable<IEmailEntity> To { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IEmailEntity From { get; set; }
        public IEnumerable<IEmailEntity> Cc { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IEnumerable<IEmailEntity> Bcc { get; set; } = Enumerable.Empty<IEmailEntity>();
        public IDictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();
        [JsonProperty(PropertyName = "TemplateLanguage")]
        public bool UseTemplateLanguage { get; set; }
        public string Id { get; set; }
        public string Subject { get; set; }

    }
}
