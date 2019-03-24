using System;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IMessageInformation
    {
        /// <summary>
        /// Unique numeric ID of the campaign this message is part of.
        /// </summary>
        int CampaignId { get; set; }
        /// <summary>
        /// Number of messages, for which click tracking is enabled.
        /// </summary>
        int ClickTrackedCount { get; set; }
        /// <summary>
        /// Unique numeric ID of the contact, to which the message was sent.
        /// </summary>
        int ContactId { get; set; }
        /// <summary>
        /// Timestamp indicating when the message was created.
        /// </summary>
        DateTime CreatedAt { get; set; }
        /// <summary>
        /// Unique numeric ID of this message.
        /// </summary>
        long Id { get; set; }
        /// <summary>
        /// Size of the message (in bytes).
        /// </summary>
        int MessageSize { get; set; }
        /// <summary>
        /// Number of messages, for which open tracking is enabled.
        /// </summary>
        int OpenTrackedCount { get; set; }
        /// <summary>
        /// Number of messages waiting in the send queue.
        /// </summary>
        int QueuedCount { get; set; }
        /// <summary>
        /// Timestamp indicating when last message was sent for the campaign.
        /// </summary>
        DateTime SendEndAt { get; set; }
        /// <summary>
        /// Number of actual sent attempts.
        /// </summary>
        int SentCount { get; set; }

        //TODO 1.0: Awaiting documentation details from Mailjet
        /// <summary>
        /// Matched SpamAssassin rules.
        /// </summary>
        JToken SpamAssassinRules { get; set; }
        /// <summary>
        /// SpamAssassin score for this message.
        /// </summary>
        int SpamAssassinScore { get; set; }
    }
}