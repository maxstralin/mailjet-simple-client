using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Options;

namespace Mailjet.SimpleClient.Tests.Static
{
    public static class Config
    {
        public static readonly IMailjetEmailOptions MailjetEmailOptions = new MailjetEmailOptions
        {
            ApiVersion = EmailApiVersion.V3_1,
            PrivateKey = "Max",
            PublicKey = "Strålin"
        };
    }
}
