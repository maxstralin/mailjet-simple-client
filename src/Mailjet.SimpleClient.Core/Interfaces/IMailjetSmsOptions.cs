using Mailjet.SimpleClient.Core.Models.Options;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// Options for Mailjet's SMS API
    /// </summary>
    public interface IMailjetSmsOptions
    {
        /// <summary>
        /// Version of the SMS API
        /// </summary>
        SmsApiVersion SmsApiVersion { get; set; }
    }
}