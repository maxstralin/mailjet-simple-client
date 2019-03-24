using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Mailjet.SimpleClient.Core.Models.Emailing;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// Retrieve the event history (sending, open, click etc.) for a specific message.
    /// </summary>
    public interface IMessageHistory
    {
        /// <summary>
        /// A comment providing additional details in case of issues with the message delivery.
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// Timestamp indicating when the event was registered.
        /// </summary>
        DateTime EventStamp { get; }

        /// <summary>
        /// The type of this event.
        /// </summary>
        EventType EventType { get; }

        /// <summary>
        /// When the message is not successfully delivered, will display the reason for non-delivery.
        /// </summary>
        string NonDeliveryReason { get; }

        /// <summary>
        /// User agent (browser) used to trigger the event (when applicable).
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// Unique numeric ID of the user agent (browser) used to trigger this event.
        /// </summary>
        int UserAgentId { get; }

    }
}
