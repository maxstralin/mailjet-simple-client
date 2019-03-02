using System.Net.Http;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// A client able to interact with Mailjet
    /// </summary>
    public interface IMailjetSimpleClient
    {
        /// <summary>
        /// Send a request to Mailjet's API
        /// </summary>
        /// <param name="request">The Mailjet request</param>
        /// <returns>A generic response</returns>
        Task<IResponse> SendRequestAsync(IMailjetRequest request);

        /// <summary>
        /// Set the HttpClient to be used for requests
        /// </summary>
        /// <param name="httpClient">HttpClient instance</param>
        void UseHttpClient(HttpClient httpClient);

    }
}
