using System;
using System.Collections.Generic;
using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Responses
{
    public class SendEmailResponse : Response, ISendEmailResponse
    {
        public SendEmailResponse(IEnumerable<ISendEmailResponseEntry> data, JToken rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }
        public SendEmailResponse(IEnumerable<ISendEmailResponseEntry> data, IResponse response) : this(data, response.RawResponse, response.StatusCode, response.Successful) { }

        //public IEnumerable<ISendEmailResponseEntry> Data { get; private set; }
        public IEnumerable<ISendEmailResponseEntry> Data { get; }
    }
}
