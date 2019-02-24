using Mailjet.SimpleClient.Entities.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetSimpleClient
    {
        Task<HttpResponseMessage> SendRequestAsync(IRequestFactory request);
    }
}
