using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses.Emailing
{
    public class GetMessagesResponse : RetrieveInfoResponse<IEnumerable<IGetMessagesResponseEntry>>, IGetMessagesResponse
    {
        public GetMessagesResponse(IEnumerable<GetMessagesResponseEntry> data, string rawResponse, int statusCode, bool successful) : base(data, rawResponse, statusCode, successful)
        {
        }
    }
}
