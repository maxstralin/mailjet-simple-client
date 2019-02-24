using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IResponse
    {
        JToken RawResponse { get; }
    }
    public interface IResponse<T> : IResponse
    {
        T Response { get; }
    }
}
