using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Abstracts
{
    /// <summary>
    /// Taking some notes from http://hannesdorfmann.com/android/library-abstract-class, it may be a good idea to have an abstract class to allow default implementations 
    /// In this case, we can't control Mailjet's API and may need to alter the <c>IMailjetEmailClient</c> interface "unexpectedly",
    /// breaking people's code if they implement the interface instead of the abstract class.
    /// (Eagerly awaiting C# 8 here)
    /// </summary>
    public abstract class MailjetEmailClientBase : IMailjetEmailClient
    {
        /// <inheritdoc />
        public virtual Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual Task<ISendEmailResponse> SendAsync(IEnumerable<IEmailMessage> emailMessages)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual Task<IGetMessagesResponse> GetMessagesAsync(IGetMessagesFilters messageFilters)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual Task<IGetMessageResponse> GetMessageAsync(long messageId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual Task<IGetMessageHistoryResponse> GetMessageHistoryAsync(long messageId)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<IRetrieveDetailsResponse<IEnumerable<IMessageInformation>>>> GetMessageInformationAsync(IGetMessagesFilters messageFilters)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<IRetrieveDetailsResponse<IMessageInformation>>> GetMessageInformationAsync(long messageId)
        {
            throw new NotImplementedException();
        }
    }
}
