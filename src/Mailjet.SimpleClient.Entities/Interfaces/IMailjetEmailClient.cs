using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetEmailClient : IVersionedClient
    {
        new EmailApiVersion ApiVersion { get; }
        void Send(IEmailMessage emailMessage);
        void Send(ITemplateEmailMessage templateEmailMessage);
        void Send(IEnumerable<ITemplateEmailMessage> templateEmailMessages);
        void Send(IEnumerable<IEmailMessage> emailMessages);
    }
}
