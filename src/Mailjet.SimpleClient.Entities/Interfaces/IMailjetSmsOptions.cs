using Mailjet.SimpleClient.Entities.Models.Options;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetSmsOptions
    {
        string Token { get; set; }
        SmsApiVersion SmsApiVersion { get; set; }
    }
}