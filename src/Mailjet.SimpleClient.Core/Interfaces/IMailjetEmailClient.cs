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
        /// <summary>
        /// Send an email 
        /// </summary>
        /// <param name="emailMessage">The email message</param>
        Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage);
        /// <summary>
        /// Send multiple email messages
        /// </summary>
        /// <param name="emailMessages">The email messages</param>
        /// <returns></returns>
        Task<ISendEmailResponse> SendAsync(IEnumerable<IEmailMessage> emailMessages);
        /// <summary>
        /// Get a list of messages with specific information on the type of content, tracking, sending and delivery.
        /// </summary>
        /// <param name="messageFilters">Filtering params</param>
        Task<IGetMessagesResponse> GetMessagesAsync(IGetMessagesFilters messageFilters);
        Task<IGetMessageResponse> GetMessageAsync(long messageId);
        /// <summary>
        /// Retrieve the event history (sending, open, click etc.) for a specific message.
        /// </summary>
        /// <param name="messageId">Message ID</param>
        Task<IGetMessageHistoryResponse> GetMessageHistoryAsync(long messageId);
        /// <summary>
        /// Retrieve sending / size / spam information about all messages
        /// </summary>
        /// <param name="messageFilters">Filtering params</param>
        Task<IResponse<IRetrieveDetailsResponse<IEnumerable<IMessageInformation>>>> GetMessageInformationAsync(IGetMessagesFilters messageFilters);
        /// <summary>
        /// Retrieve sending / size / spam information about a specific message ID
        /// </summary>
        /// <param name="messageId">Message ID</param>
        Task<IResponse<IRetrieveDetailsResponse<IMessageInformation>>> GetMessageInformationAsync(long messageId);

    }
}