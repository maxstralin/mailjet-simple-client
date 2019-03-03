using Mailjet.SimpleClient.Core.Models.Options;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// Options for Mailjet's email API
    /// </summary>
    public interface IMailjetEmailOptions
    {
        /// <summary>
        /// Email API version
        /// </summary>
        EmailApiVersion EmailApiVersion { get; set; }
        /// <summary>
        /// Dry run the request
        /// </summary>
        bool SandboxMode { get; set; }
    }
}