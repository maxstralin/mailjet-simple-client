using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Client
{
    public class MailjetSimpleClient : IVersionedClient, IVersionlessClient, IMailjetSimpleClient
    {
        public ApiVersion ApiVersion { get => MailjetOptions.ApiVersion; set => MailjetOptions.ApiVersion = value; }
        public IMailjetOptions MailjetOptions { get; protected set; } = null;
        public MailjetSimpleClient(IMailjetOptions options)
        {
            MailjetOptions = options;
        }
        public IVersionedClient SetVersion(ApiVersion apiVersion)
        {
            ApiVersion = apiVersion;
            return this;
        }
        
        public Task<HttpResponseMessage> SendRequestAsync(IRequestFactory request)
        {
            return SendRequestAsync(ApiVersion, request);
        }

        public Task<HttpResponseMessage> SendRequestAsync(ApiVersion apiVersion, IRequestFactory request)
        {
            throw new NotImplementedException();
        }
    }


}
