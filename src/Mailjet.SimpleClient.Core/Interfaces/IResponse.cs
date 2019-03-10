using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Interfaces
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
        /// Raw response data
        /// </summary>
        string RawResponse { get; }

        /// <summary>
        /// Response body parsed into JSON token
        /// </summary>
        JToken ParsedResponse { get; }

        IError Error { get; }
    }
    /// <inheritdoc />
    /// <summary>
    /// An API response with a specific response data type
    /// </summary>
    /// <typeparam name="T">The type of the response data</typeparam>
    public interface IResponse<out T> : IResponse where T : class
    {
        /// <summary>
        /// The deserialised data received back from the API
        /// </summary>
        T Data { get; }
    }
}
