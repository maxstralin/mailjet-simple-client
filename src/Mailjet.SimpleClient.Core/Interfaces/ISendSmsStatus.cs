using Mailjet.SimpleClient.Core.Models.Sms;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendSmsStatus
    {
        SmsStatus SmsStatus { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}