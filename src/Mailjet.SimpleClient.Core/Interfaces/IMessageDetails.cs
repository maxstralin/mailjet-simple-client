using System;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IMessageDetails
    {
        /// <summary>
        /// Timestamp indicating when the message arrived in the recipient's mailbox.
        /// </summary>
        DateTime ArrivedAt { get; set; }

        /// <summary>
        /// Number of attachments detected for this message.
        /// </summary>
        int AttachmentCount { get; set; }

        /// <summary>
        /// Number of attempts made to deliver this message.
        /// </summary>
        int AttemptCount { get; set; }

        /// <summary>
        /// The email address of the contact, to which the message was sent. Displayed only when ShowContactAlt=true.
        /// </summary>
        string ContactAlt { get; set; }

        /// <summary>
        /// Unique numeric ID for the contact, to which the message was sent.
        /// </summary>
        int ContactId { get; set; }

        /// <summary>
        /// Delay between the message being processed and it being delivered (in milliseconds).
        /// </summary>
        int ProcessingDelay { get; set; }

        /// <summary>
        /// Unique numeric ID of the recipient email's domain.
        /// </summary>
        int DestinationId { get; set; }

        /// <summary>
        /// Time spent processing the text of the message (in milliseconds).
        /// </summary>
        int FilterTime { get; set; }

        /// <summary>
        /// Unique numeric ID of this message.
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Indicates whether clicks are tracked for this message or not.
        /// </summary>
        bool IsClickTracked { get; set; }

        /// <summary>
        /// Indicates whether the message includes any HTML content or not.
        /// </summary>
        bool IsHtmlPartIncluded { get; set; }

        /// <summary>
        /// Indicates whether opens are tracked for this message or not
        /// </summary>
        bool IsOpenTracked { get; set; }

        /// <summary>
        /// Indicates whether the message includes a plain text part or not.
        /// </summary>
        bool IsTextPartIncluded { get; set; }

        /// <summary>
        /// Indicates whether unsubscriptions are tracked for this message or not.
        /// </summary>
        bool IsUnsubTracked { get; set; }

        /// <summary>
        /// Indicates the message size (in bytes).
        /// </summary>
        int MessageSize { get; set; }

        /// <summary>
        /// Unique numeric ID of the sender email address.
        /// </summary>
        long SenderID { get; set; }

        /// <summary>
        /// SpamAssassin score for this message.
        /// </summary>
        int SpamassassinScore { get; set; }

        /// <summary>
        /// Matched SpamAssassin rules.
        /// </summary>
        //TODO 1.0: Awaiting documentation details from Mailjet
        JToken SpamassassinRules { get; set; }

        /// <summary>
        /// Indicates whether the current state of the message is permanent (i.e. cannot be changed anymore) or not.
        /// </summary>
        bool StatePermanent { get; set; }

        EmailStatus Status { get; set; }

        /// <summary>
        /// The subject line for this message. Displayed only when ShowSubject=true.
        /// </summary>
        string Subject { get; set; }

        /// <summary>
        /// Unique 128-bit ID for this message.
        /// </summary>
        string Uuid { get; set; }
    }
}