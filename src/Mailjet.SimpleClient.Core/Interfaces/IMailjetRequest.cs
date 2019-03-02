using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IMailjetRequest 
    {
        string Uri { get; }
        string UserAgent { get; }
        JToken RequestBody { get; }
        AuthenticationHeaderValue AuthenticationHeaderValue { get;  }
        HttpMethod HttpMethod { get; }
    }
}
