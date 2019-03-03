using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Serialisers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Requests
{
    public abstract class BaseRequest : IMailjetRequest
    {
        public string BaseUri { get; protected set; } = "https://api.mailjet.com";
        public string Path { get; protected set; } = string.Empty;
        public string Uri => $"{BaseUri}/{Path}";
        public string UserAgent => "mailjet-simple-client/1.0";
        public JToken RequestBody { get; protected set; }
        public AuthenticationHeaderValue AuthenticationHeaderValue { get; protected set; }
        public HttpMethod HttpMethod { get; protected set; }

        protected void SetRequestBody(object obj, JsonSerializer jsonSerializer = null)
        {
            RequestBody = MailjetSerialiser.Serialise(obj, jsonSerializer);
        }
    }
}
