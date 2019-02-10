using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models
{
    public class MailjetRequest : IRequest
    {
        private readonly JToken data;
        private readonly HttpMethod httpMethod;
        private readonly string uri;
        private readonly AuthenticationHeaderValue authentication;

        public MailjetRequest(JToken data, HttpMethod httpMethod, string uri, AuthenticationHeaderValue authentication)
        {
            this.data = data;
            this.httpMethod = httpMethod;
            this.uri = uri;
            this.authentication = authentication;
        }

        public HttpRequestMessage CreateRequest()
        {
            var req = new HttpRequestMessage(httpMethod, uri)
            {
                Content = new StringContent(data.ToString(Newtonsoft.Json.Formatting.None), Encoding.UTF8, "application/json")
            };
            req.Headers.Authorization = authentication;
            return req;
        }
    }
}
