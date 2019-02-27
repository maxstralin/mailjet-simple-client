using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IResponse
    {
        int StatusCode { get; }
        bool Successful { get; }
        JToken RawResponse { get; }
        IResponse<T> WithData<T>() where T : class;
    }
    public interface IResponse<T> : IResponse where T : class
    {
        T Data { get; }
    }
}
