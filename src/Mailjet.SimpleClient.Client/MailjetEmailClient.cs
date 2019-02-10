using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Mailjet.SimpleClient.Client
{
    public class MailjetEmailClient : IMailjetEmailClient
    {
        protected MailjetEmailClient(EmailApiVersion emailApiVersion)
        {
        }

        public EmailApiVersion ApiVersion { get; }

        public IMailjetEmailOptions MailjetEmailOptions { get; } = new MailjetEmailOptions();

        ApiVersion IVersionedClient.ApiVersion => (ApiVersion)ApiVersion;

        private JToken GetJToken(IEmailMessage emailMessage)
        {
            switch (ApiVersion)
            {
                //TODO: Implement contract resolver
                case EmailApiVersion.V3:
                    throw new UnsupportedApiVersionException();
                case EmailApiVersion.V3_1:
                    return JToken.FromObject(emailMessage);
                default:
                    throw new UnsupportedApiVersionException();
            }
        }

        public void Send(IEnumerable<IEmailMessage> emailMessages)
        {
            JToken.FromObject(emailMessages, new Newtonsoft.Json.JsonSerializer
            {
                ContractResolver = new DefaultContractResolver()
            });
        }
        HttpResponseMessage IMailjetSimpleClient.SendRequest(IRequest request)
        {
            throw new NotImplementedException();
        }

        public void Send(IEmailMessage emailMessage)
        {
            throw new NotImplementedException();
        }

        public void Send(ITemplateEmailMessage templateEmailMessage)
        {
            throw new NotImplementedException();
        }

        public void Send(IEnumerable<ITemplateEmailMessage> templateEmailMessages)
        {
            throw new NotImplementedException();
        }
        public void Send(params ITemplateEmailMessage[] templateEmailMessages) => Send(templateEmailMessages);

    }
}