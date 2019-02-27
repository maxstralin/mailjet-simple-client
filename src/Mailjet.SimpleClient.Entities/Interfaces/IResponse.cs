using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// An API response
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Status code received back from the API
        /// </summary>
        int StatusCode { get; }
        /// <summary>
        /// If the response indicate success
        /// </summary>
        bool Successful { get; }
        /// <summary>
        /// Raw JSON data
        /// </summary>
        JToken RawResponse { get; }
        /// <summary>
        /// Convert the raw response to a type
        /// </summary>
        /// <typeparam name="T">The type of the response data</typeparam>
        /// <returns>The raw data converted</returns>
        IResponse<T> WithData<T>() where T : class;
    }
    /// <summary>
    /// An API response with a specific response data type
    /// </summary>
    /// <typeparam name="T">The type of the response data</typeparam>
    public interface IResponse<T> : IResponse where T : class
    {
        /// <summary>
        /// The deserialised data received back from the API
        /// </summary>
        T Data { get; }
    }
}
