using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses
{
    public abstract class RetrieveInfoResponse<T> : ResponseBase, IResponse<T> where T : class
    {
        protected RetrieveInfoResponse(T data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }

        public int Count { get; set; }
        public int Total { get; set; }
        public T Data { get; set; }
    }
}
