using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models
{
    public class TemplateEmailMessage : ITemplateEmailMessage
    {
        public int TemplateId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDictionary<string, object> Variables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseTemplateLanguage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEmailEntity From { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IEmailEntity> To { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IEmailEntity> Cc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IEmailEntity> Bcc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
