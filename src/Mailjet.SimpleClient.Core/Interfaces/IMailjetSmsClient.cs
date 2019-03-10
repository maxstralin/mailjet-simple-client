using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IMailjetSmsClient
    {
        Task<ISendSmsResponse> SendAsync(ISmsMessage smsMessage);
        Task<IEnumerable<ISendSmsResponse>> SendAsync(IEnumerable<ISmsMessage> smsMessages);
    }
}