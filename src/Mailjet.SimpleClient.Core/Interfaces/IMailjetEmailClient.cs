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
        /// <summary>
        /// Get a list of messages with specific information on the type of content, tracking, sending and delivery.
        /// </summary>
        /// <param name="messageFilters">Filtering params</param>
        /// <returns></returns>
        Task<IGetMessagesResponse> GetMessagesAsync(IMessageFilters messageFilters);
        Task<IGetMessageResponse> GetMessageAsync(long messageId);
        Task<IResponse> GetMessageHistoryAsync(long messageId);
        Task<IResponse> GetMessageHistoryAsync(IQueryFilter queryFilter);

    }
}