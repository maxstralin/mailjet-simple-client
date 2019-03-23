using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses.Emailing
{
    public class GetMessageResponse : ResponseBase, IGetMessageResponse
    {
        public GetMessageResponse(IRetrieveDetailsResponse<IMessageDetails> data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }

        public IRetrieveDetailsResponse<IMessageDetails> Data { get; }
    }
}
