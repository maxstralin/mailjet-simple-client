using System.Collections.Generic;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Options;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// A client for interacting with Mailjet for the purpose of sending emails
    /// </summary>
    /// <typeparam name="TResponse">Type of the response after sending an email</typeparam>
    public interface IMailjetEmailClient<TResponse> where TResponse : class
    {
        Task<IResponse<TResponse>> SendAsync(IEmailMessage emailMessage);
        Task<IResponse<TResponse>> SendAsync(IEnumerable<IEmailMessage> emailMessages);
    }
}