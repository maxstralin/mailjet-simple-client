using System.Collections.Generic;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Models.Responses.Emailing;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// A client for interacting with Mailjet for the purpose of sending emails
    /// </summary>
    public interface IMailjetEmailClient
    {
        Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage);
        Task<ISendEmailResponse> SendAsync(IEnumerable<IEmailMessage> emailMessages);
        Task<IGetMessagesResponse> GetMessagesAsync(IQueryFilter queryFilter);
        Task<IResponse> GetMessageAsync(int messageId);
        Task<IResponse> GetMessageHistoryAsync(int messageId);
        Task<IResponse> GetMessageHistoryAsync(IQueryFilter queryFilter);

    }
}