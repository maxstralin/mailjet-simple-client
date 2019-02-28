using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Requests
{
    public abstract class BaseRequest : IRequestFactory
    {
        public string BaseUrl { get; protected set; } = "https://api.mailjet.com";
        public string Path { get; protected set; } = string.Empty;
        public string FullUrl => $"{BaseUrl}/{Path}";
        public string UserAgent => "mailjet-simple-client/1.0";
        public JToken RequestBody { get; protected set; }
        public AuthenticationHeaderValue AuthenticationHeaderValue { get; protected set; }
        public HttpMethod HttpMethod { get; protected set; }

        protected virtual StringContent CreateStringContent(JToken requestBody)
        {
            return new StringContent(requestBody.ToString(), Encoding.UTF8, "application/json");
        }
        protected void SetRequestBody(object obj, JsonSerializer jsonSerializer = null)
        {
            var serialiser = jsonSerializer ?? new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            RequestBody = JToken.FromObject(obj, serialiser);
        }

        public virtual HttpRequestMessage CreateRequest()
        {
            var msg = new HttpRequestMessage
            {
                Content = CreateStringContent(RequestBody),
                RequestUri = new Uri(FullUrl),
                Method = HttpMethod,
            };
            msg.Headers.Authorization = AuthenticationHeaderValue;
            msg.Headers.UserAgent.ParseAdd(UserAgent);
            return msg;
        }
    }
}
