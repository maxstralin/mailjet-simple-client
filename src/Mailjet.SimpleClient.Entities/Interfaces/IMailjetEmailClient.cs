using System.Collections.Generic;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Options;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetEmailClient<TResponse> where TResponse : class
    {
        EmailApiVersion ApiVersion { get; }
        IMailjetEmailOptions MailjetEmailOptions { get; }

        Task<IResponse<TResponse>> SendAsync(IEmailMessage emailMessage);
        Task<IResponse<TResponse>> SendAsync(IEnumerable<IEmailMessage> emailMessages);
    }
}