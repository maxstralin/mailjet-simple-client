using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Responses
{
    public abstract class BaseResponse : IResponse
    {
        public JToken RawResponse { get; protected set; }
    }
    public abstract class BaseResponse<T> : BaseResponse, IResponse<T>
    {
        public T Response => RawResponse.ToObject<T>();
    }
}
