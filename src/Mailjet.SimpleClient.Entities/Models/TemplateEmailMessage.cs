using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models
{
    public class TemplateEmailMessage : ITemplateEmailMessage, IEmailMessage
    {
        public TemplateEmailMessage(int templateId)
        {
            TemplateId = templateId;
        }
        public int TemplateId { get; set; }
        public IDictionary<string, object> Variables { get; set; }
        public bool UseTemplateLanguage { get; set; }
        public IEmailEntity From { get; set; }
        public IEnumerable<IEmailEntity> To { get; set; }
        public IEnumerable<IEmailEntity> Cc { get; set; }
        public IEnumerable<IEmailEntity> Bcc { get; set; }
        string IEmailMessage.HtmlBody { get => null; set => throw new InvalidOperationException("HtmlBody cannot be set for templated messages"); }
        string IEmailMessage.PlainTextBody { get => null; set => throw new InvalidOperationException("PlainTextBody cannot be set for templated messages"); }
        public string Id { get; set; }
    }
}
