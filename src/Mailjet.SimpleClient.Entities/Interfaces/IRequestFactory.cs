using System.Net.Http;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// Something that is able to create a HttpRequestMessage
    /// </summary>
    public interface IRequestFactory
    {
        /// <summary>
        /// Create a HttpRequestMessage to use for sending request to an API
        /// </summary>
        /// <returns>A HttpRequestMessage</returns>
        HttpRequestMessage CreateRequest();
    }
}
