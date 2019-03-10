using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Responses.Sms
{
    public class SendSmsResponse : ResponseBase, ISendSmsResponse
    {
        public SendSmsResponse(ISendSmsResponseEntry data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }

        public ISendSmsResponseEntry Data { get; }
    }
}
