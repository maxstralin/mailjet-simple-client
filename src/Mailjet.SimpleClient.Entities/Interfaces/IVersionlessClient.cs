using Mailjet.SimpleClient.Entities.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IVersionlessClient : IMailjetSimpleClient
    {
        IVersionedClient SetVersion(ApiVersion apiVersion);
        Task<HttpResponseMessage> SendRequestAsync(ApiVersion apiVersion, IRequestFactory request);
    }
}
