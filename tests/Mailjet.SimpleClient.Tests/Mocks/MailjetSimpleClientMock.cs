using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Tests.Mocks
{
    public class MailjetSimpleClientMock : IMailjetSimpleClient
    {
        public Task<IResponse> SendRequestAsync(IRequestFactory requestFactory)
        {
            throw new NotImplementedException();
        }

        public void UseHttpClient(HttpClient httpClient)
        {
            throw new NotImplementedException();
        }
    }
}
