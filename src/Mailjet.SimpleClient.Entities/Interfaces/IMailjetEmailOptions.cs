using Mailjet.SimpleClient.Entities.Models;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetEmailOptions
    {
        string PublicKey { get; set; }
        string PrivateKey { get; set; }
        EmailApiVersion ApiVersion { get; set; }
    }
}