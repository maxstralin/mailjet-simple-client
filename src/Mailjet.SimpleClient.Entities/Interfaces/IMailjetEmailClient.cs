using System.Collections.Generic;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Options;

namespace Mailjet.SimpleClient.Entities.Interfaces
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