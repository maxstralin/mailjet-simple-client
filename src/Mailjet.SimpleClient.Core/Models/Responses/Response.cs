﻿using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Errors;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Responses
{
    public class Response : IResponse
    {
        public Response(JToken rawResponse, int statusCode, bool successful)
        {
            RawResponse = rawResponse;
            StatusCode = statusCode;
            Successful = successful;

            //Seems to be an error response, populate the Error property
            if (RawResponse[nameof(Error.ErrorIdentifier)] != null)
            {
                Error = RawResponse.ToObject<Error>();
            }

        }
        public JToken RawResponse { get; protected set; }
        public IError Error { get; }

        public int StatusCode { get; protected set; }

        public bool Successful { get; protected set; }
    }
}