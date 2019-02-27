using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// A client able to interact with Mailjet
    /// </summary>
    public interface IMailjetSimpleClient
    {
        /// <summary>
        /// Send a request to Mailjet's API
        /// </summary>
        /// <param name="requestFactory">The factory which create the request</param>
        /// <returns>A generic response</returns>
        Task<IResponse> SendRequestAsync(IRequestFactory requestFactory);
    }
}
