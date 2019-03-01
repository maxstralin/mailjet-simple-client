using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Tests.Mocks
{
    class MailjetEmailClientMock : IMailjetEmailClient
    {
        public Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage)
        {
            throw new NotImplementedException();
        }

        public Task<ISendEmailResponse> SendAsync(IEnumerable<IEmailMessage> emailMessages)
        {
            throw new NotImplementedException();
        }
    }
}
