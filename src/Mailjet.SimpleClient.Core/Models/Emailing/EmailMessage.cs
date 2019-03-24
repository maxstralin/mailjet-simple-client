using System;
using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public class EmailMessage : BaseEmailMessage
    {
        /// <summary>
        /// Initialise an empty email
        /// </summary>
        public EmailMessage() { }

        /// <summary>
        /// Initialise an email message with a sender name and email
        /// </summary>
        /// <param name="senderName">Name in From</param>
        /// <param name="senderEmail">Email in From</param>
        public EmailMessage(string senderName, string senderEmail) : this(new EmailEntity(senderName, senderEmail)) { }

        /// <summary>
        /// Initialise an email with an IEmailEntity
        /// </summary>
        /// <param name="from">An email entity instance</param>
        public EmailMessage(IEmailEntity from)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
        }
        
        /// <summary>
        /// The HTML body
        /// </summary>
        [JsonProperty("HtmlPart")]
        public string HtmlBody { get; set; }
        /// <summary>
        /// Plain text body
        /// </summary>
        [JsonProperty("TextPart")]
        public string PlainTextBody { get; set; }
        
    }
}
