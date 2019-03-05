using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Sms
{
    public class SmsMessage : ISmsMessage
    {
        /// <inheritdoc />
        public string From { get; set; }
        /// <inheritdoc />
        public string Text { get; set; }
        /// <inheritdoc />
        public string To { get; set; }   
    }
}
