using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Emailing
{
    public class TemplateEmailMessage : EmailMessage, ITemplateEmailMessage
    {
        public TemplateEmailMessage(int templateId, IEmailEntity from) : base(from)
        {
            TemplateId = templateId;
        }
        [JsonProperty(PropertyName = "TemplateID")]
        public int TemplateId { get; set; }
    }
}
