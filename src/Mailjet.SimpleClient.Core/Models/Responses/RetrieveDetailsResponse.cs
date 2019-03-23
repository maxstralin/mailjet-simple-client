using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses
{
    public class RetrieveDetailsResponse<T> : IRetrieveDetailsResponse<T>
    {
        public int Count { get; set; }
        public int Total { get; set; }
        public T Data { get; set; }
    }
}
