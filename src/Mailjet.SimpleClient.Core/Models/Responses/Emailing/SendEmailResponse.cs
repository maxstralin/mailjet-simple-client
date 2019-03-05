using System.Collections.Generic;
using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Responses.Emailing
{
    public class SendEmailResponse : ResponseBase, ISendEmailResponse
    {
        public SendEmailResponse(IEnumerable<ISendEmailResponseEntry> data, JToken rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }
        public SendEmailResponse(IEnumerable<ISendEmailResponseEntry> data, IResponse response) : this(data, response.RawResponse, response.StatusCode, response.Successful) { }

        public IEnumerable<ISendEmailResponseEntry> Data { get; }
    }
}
