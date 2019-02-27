using Mailjet.SimpleClient.Entities.Models.Options;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// Options for Mailjet's SMS API
    /// </summary>
    public interface IMailjetSmsOptions
    {
        /// <summary>
        /// Bearer token
        /// </summary>
        string Token { get; set; }
        /// <summary>
        /// Version of the SMS API
        /// </summary>
        SmsApiVersion SmsApiVersion { get; set; }
    }
}