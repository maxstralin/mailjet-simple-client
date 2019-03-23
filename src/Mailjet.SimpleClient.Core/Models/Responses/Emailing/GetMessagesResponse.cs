using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses.Emailing
{
    public class GetMessagesResponse : ResponseBase, IGetMessagesResponse
    {
        public GetMessagesResponse(IRetrieveDetailsResponse<IEnumerable<IGetMessagesResponseEntry>> data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }

        public IRetrieveDetailsResponse<IEnumerable<IGetMessagesResponseEntry>> Data { get; }
    }
}
