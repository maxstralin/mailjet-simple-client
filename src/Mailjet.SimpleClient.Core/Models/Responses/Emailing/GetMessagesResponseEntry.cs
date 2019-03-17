using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mailjet.SimpleClient.Core.Models.Responses.Emailing
{
    public class GetMessagesResponseEntry : IGetMessagesResponseEntry
    {
        /// <summary>
        /// Timestamp indicating when the message arrived in the recipient's mailbox.
        /// </summary>
        public DateTime ArrivedAt { get; set; }
        /// <summary>
        /// Number of attachments detected for this message.
        /// </summary>
        public int AttachmentCount { get; set; }
        /// <summary>
        /// Number of attempts made to deliver this message.
        /// </summary>
        public int AttemptCount { get; set; }
        /// <summary>
        /// The email address of the contact, to which the message was sent. Displayed only when ShowContactAlt=true.
        /// </summary>
        public string ContactAlt { get; set; }
        /// <summary>
        /// Unique numeric ID for the contact, to which the message was sent.
        /// </summary>
        [JsonProperty("ContactID")]
        public int ContactId { get; set; }
        /// <summary>
        /// Delay between the message being processed and it being delivered (in milliseconds).
        /// </summary>
        [JsonProperty("Delay")]
        public int ProcessingDelay { get; set; }
        /// <summary>
        /// Unique numeric ID of the recipient email's domain.
        /// </summary>
        [JsonProperty("DestinationID")]
        public int DestinationId { get; set; }
        /// <summary>
        /// Time spent processing the text of the message (in milliseconds).
        /// </summary>
        public int FilterTime { get; set; }
        /// <summary>
        /// Unique numeric ID of this message.
        /// </summary>
        [JsonProperty("Id")]
        public long Id { get; set; }
        /// <summary>
        /// Indicates whether clicks are tracked for this message or not.
        /// </summary>
        public bool IsClickTracked { get; set; }
        /// <summary>
        /// Indicates whether the message includes any HTML content or not.
        /// </summary>
        [JsonProperty("IsHTMLPartIncluded")]
        public bool IsHtmlPartIncluded { get; set; }
        /// <summary>
        /// Indicates whether opens are tracked for this message or not
        /// </summary>
        public bool IsOpenTracked { get; set; }
        /// <summary>
        /// Indicates whether the message includes a plain text part or not.
        /// </summary>
        public bool IsTextPartIncluded { get; set; }
        /// <summary>
        /// Indicates whether unsubscriptions are tracked for this message or not.
        /// </summary>
        public bool IsUnsubTracked { get; set; }
        /// <summary>
        /// Indicates the message size (in bytes).
        /// </summary>
        public int MessageSize { get; set; }
        /// <summary>
        /// Unique numeric ID of the sender email address.
        /// </summary>
        [JsonProperty("SenderID")]
        public long SenderID { get; set; }
        /// <summary>
        /// SpamAssassin score for this message.
        /// </summary>
        public int SpamassassinScore { get; set; }
        /// <summary>
        /// Matched SpamAssassin rules.
        /// </summary>
        //TODO: Awaiting reply from Mailjet of what this string will contain, may be an IEnumerable<string>
        [JsonProperty("SpamassRules")]
        public string SpamassassinRules { get; set; }
        /// <summary>
        /// Indicates whether the current state of the message is permanent (i.e. cannot be changed anymore) or not.
        /// </summary>
        public bool StatePermanent { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EmailStatus Status { get; set; }
        /// <summary>
        /// The subject line for this message. Displayed only when ShowSubject=true.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Unique 128-bit ID for this message.
        /// </summary>
        [JsonProperty("UUID")]
        public string Uuid { get; set; }
    }
}
