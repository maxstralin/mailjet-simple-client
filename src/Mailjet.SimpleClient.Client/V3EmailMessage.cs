using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Client
{
    internal class V3EmailMessage : IEmailMessage
    {
        public string HtmlBody { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PlainTextBody { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseTemplateLanguage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDictionary<string, object> Variables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IEmailEntity> To { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IEmailEntity> From { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IEmailEntity> Cc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<IEmailEntity> Bcc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
