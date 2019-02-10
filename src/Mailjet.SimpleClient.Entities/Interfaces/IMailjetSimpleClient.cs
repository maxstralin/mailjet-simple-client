using Mailjet.SimpleClient.Entities.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetSimpleClient
    {
        HttpResponseMessage SendRequest(IRequest request);
    }
}
