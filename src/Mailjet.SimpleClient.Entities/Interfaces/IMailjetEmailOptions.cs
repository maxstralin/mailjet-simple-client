using Mailjet.SimpleClient.Entities.Models.Options;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// Options for Mailjet's email API
    /// </summary>
    public interface IMailjetEmailOptions
    {
        /// <summary>
        /// Public key for Mailjet email API
        /// </summary>
        string PublicKey { get; set; }
        /// <summary>
        /// Private/secret key for Mailjet email API
        /// </summary>
        string PrivateKey { get; set; }
        /// <summary>
        /// Email API version
        /// </summary>
        EmailApiVersion ApiVersion { get; set; }
        /// <summary>
        /// Dry run the request
        /// </summary>
        bool SandboxMode { get; set; }
    }
}