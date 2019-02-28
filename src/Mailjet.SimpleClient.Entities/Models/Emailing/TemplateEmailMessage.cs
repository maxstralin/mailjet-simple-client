using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using System;

namespace Mailjet.SimpleClient.Entities.Models.Emailing
{
    public class TemplateEmailMessage : BaseEmailMessage, ITemplateEmailMessage
    {
        /// <summary>
        /// Initialise an email with an IEmailEntity
        /// </summary>
        /// <param name="templateId">The ID of the template</param>
        /// <param name="from">An email entity instance</param>
        public TemplateEmailMessage(int templateId, IEmailEntity from)
        {
            TemplateId = templateId;
            From = from ?? throw new ArgumentNullException(nameof(from));
        }

        /// <summary>
        /// Initialise an email message with a sender name and email
        /// </summary>
        /// <param name="templateId">The ID of the template</param>
        /// <param name="senderName">Name in From</param>
        /// <param name="senderEmail">Email in From</param>
        public TemplateEmailMessage(int templateId, string senderName, string senderEmail) : this(templateId, new EmailEntity(senderName, senderEmail)) { }
        [JsonProperty(PropertyName = "TemplateID")]
        public int TemplateId { get; }
    }
}
