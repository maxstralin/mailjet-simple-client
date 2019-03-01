using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// A client for interacting with Mailjet for the purpose of sending emails
    /// </summary>
    public interface IMailjetEmailClient
    {
        Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage);
        Task<ISendEmailResponse> SendAsync(IEnumerable<IEmailMessage> emailMessages);
    }
}