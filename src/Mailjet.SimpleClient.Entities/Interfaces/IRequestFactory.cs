using System.Net.Http;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// Something that is able to create an IMailjetRequest
    /// </summary>
    public interface IRequestFactory
    {
        /// <summary>
        /// Create a IMailjetRequest to use for sending request to an API
        /// </summary>
        /// <returns>A IMailjetRequest</returns>
        IMailjetRequest CreateRequest();
    }
}
