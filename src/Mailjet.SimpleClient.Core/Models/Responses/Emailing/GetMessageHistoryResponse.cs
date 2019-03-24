using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses.Emailing
{
    public class GetMessageHistoryResponse : ResponseBase, IGetMessageHistoryResponse
    {
        public GetMessageHistoryResponse(IRetrieveDetailsResponse<IEnumerable<IMessageHistory>> data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }

        public IRetrieveDetailsResponse<IEnumerable<IMessageHistory>> Data { get; }
    }
}
