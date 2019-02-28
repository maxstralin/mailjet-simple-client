using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Responses
{
    public class Response : IResponse
    {
        public Response(JToken rawResponse, int statusCode, bool successful)
        {
            RawResponse = rawResponse;
            StatusCode = statusCode;
            Successful = successful;
        }
        public JToken RawResponse { get; protected set; }

        public int StatusCode { get; protected set; }

        public bool Successful { get; protected set; }
    }
}
