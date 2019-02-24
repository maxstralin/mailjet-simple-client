using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
}
