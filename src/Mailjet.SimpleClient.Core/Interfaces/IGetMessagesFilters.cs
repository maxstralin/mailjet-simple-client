using System;
using System.Collections.Generic;
using Mailjet.SimpleClient.Core.Models.Emailing;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IGetMessagesFilters : IQueryFilter
    {
        /// <summary>
        /// Retrieves only messages sent as part of the specified Campaign ID.
        /// </summary>
        int? CampaignId { get; set; }

        /// <summary>
        /// Retrieves only messages sent to the specified Contact ID.
        /// </summary>
        int? ContactId { get; set; }

        /// <summary>
        /// Retrieves only messages tagged with the specified CustomID.
        /// </summary>
        string CustomId { get; set; }

        /// <summary>
        /// Retrieves only messages sent from the specified Sender Email address.
        /// </summary>
        string From { get; set; }
        
        /// <summary>
        /// Retrieves only messages sent from the specified sender domain.
        /// </summary>
        string FromDomain { get; set; }

        /// <summary>
        /// Retrieves only messages sent from the sender address with the specified ID.
        /// </summary>
        string FromId { get; set; }

        /// <summary>
        /// Retrieves only messages with the specified status
        /// </summary>
        EmailStatus? EmailStatus { get; set; }

        /// <summary>
        /// Retrieves only non-delivered messages with the respective State ID. The MessageState ID explains why a message was not delivered successfully to the recipient
        /// </summary>
        EmailState EmailState { get; set; }

        /// <summary>
        /// Retrieves only messages sent after the specified timestamp.
        /// </summary>
        DateTime? FromTimestamp { get; set; }

        /// <summary>
        /// Retrieves only messages of the specified type
        /// </summary>
        EmailType? FromType { get; set; }

        /// <summary>
        /// Retrieves only messages sent before the specified timestamp.
        /// </summary>
        DateTime? ToTimestamp { get; set; }

        /// <summary>
        /// Retrieve a list of objects starting from a certain offset. Combine this query parameter with Limit to retrieve a specific section of the list of objects. Defaults to 0.
        /// </summary>
        int? Offset { get; set; }

        /// <summary>
        /// Limit the response to a select number of returned objects.
        /// Default value: 10. Maximum value: 1000
        /// </summary>
        int? Limit { get; set; }

        bool CountOnly { get; set; }
    }
}