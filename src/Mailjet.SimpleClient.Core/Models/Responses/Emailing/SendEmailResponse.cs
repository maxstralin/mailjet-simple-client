using System.Collections.Generic;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Errors;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Responses.Emailing
{
    public class SendEmailResponse : ResponseBase, ISendEmailResponse
    {
        public SendEmailResponse(IEnumerable<ISendEmailResponseEntry> data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            
            Data = data;
        }
        public SendEmailResponse(IEnumerable<ISendEmailResponseEntry> data, IResponse response) : this(data, response.RawResponse, response.StatusCode, response.Successful) { }

        public IEnumerable<ISendEmailResponseEntry> Data { get; }

    }
}
