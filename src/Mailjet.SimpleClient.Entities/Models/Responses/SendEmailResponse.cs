using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Responses
{
    public class SendEmailResponse : Response, ISendEmailResponse
    {
        public SendEmailResponse(IEnumerable<ISendEmailResponseEntry> data, JToken rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
        public SendEmailResponse(IEnumerable<ISendEmailResponseEntry> data, IResponse response) : this(data, response.RawResponse, response.StatusCode, response.Successful) { }

        public IEnumerable<ISendEmailResponseEntry> Data { get; private set; }
    }
}
