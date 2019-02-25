using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Options;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetEmailOptions
    {
        string PublicKey { get; set; }
        string PrivateKey { get; set; }
        EmailApiVersion ApiVersion { get; set; }
        bool SandboxMode { get; set; }
    }
}