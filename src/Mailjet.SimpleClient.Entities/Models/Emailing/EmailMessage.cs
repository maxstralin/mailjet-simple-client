using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using System;

namespace Mailjet.SimpleClient.Entities.Models.Emailing
{
    //TODO: JsonConstructor for deserialising (can't deserialise to interfaces)
    //TODO: Add plenty more properties, e.g. TemplateErrorReporting, Attachments, etc: https://dev.mailjet.com/guides/?csharp#send-api-json-properties
    public class EmailMessage : BaseEmailMessage
    {
        /// <summary>
        /// Initialise an email with an IEmailEntity
        /// </summary>
        /// <param name="from">An email entity instance</param>
        public EmailMessage(IEmailEntity from)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
        }
        /// <summary>
        /// Initialise an email message with a sender name and email
        /// </summary>
        /// <param name="senderName">Name in From</param>
        /// <param name="senderEmail">Email in From</param>
        public EmailMessage(string senderName, string senderEmail) : this(new EmailEntity(senderName, senderEmail)) { }
        [JsonProperty(PropertyName = "HtmlPart")]
        public string HtmlBody { get; set; }
        [JsonProperty(PropertyName = "TextPart")]
        public string PlainTextBody { get; set; }
    }
}
