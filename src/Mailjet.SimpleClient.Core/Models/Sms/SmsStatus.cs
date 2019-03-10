using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Models.Sms
{
    public enum SmsStatus
    {
        /// <summary>
        /// There is no record in Mailjet for the status code returned by the provider.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Message is being sent
        /// </summary>
        SentPending = 1,
        /// <summary>
        /// Message sent
        /// </summary>
        Sent = 2,
        /// <summary>
        /// Message delivered
        /// </summary>
        Delivered = 3,
        /// <summary>
        /// Message rejected by the operator
        /// </summary>
        RejectedOperator = 4,
        /// <summary>
        /// Message declared as "undelivered" by the operator
        /// </summary>
        RejectedUndelivered = 5,
        /// <summary>
        /// Message has been sent to the operator but expired
        /// </summary>
        RejectedExpired = 6,
        /// <summary>
        /// Message has been sent to the operator but the delivery report is not correct
        /// </summary>
        RejectedIncorrectDelivery = 7,
        /// <summary>
        /// Message has been sent to the operator but encountered a network or setup issue
        /// </summary>
        RejectedNetwork = 8,
        /// <summary>
        /// Message has been sent to the operator but recipient is subscribed to Do Not Disturb services
        /// </summary>
        RejectedDnd = 9,
        /// <summary>
        /// Message rejected because sender is blacklisted
        /// </summary>
        RejectedFromBlacklist = 10,
        /// <summary>
        /// Message rejected because recipient is blacklisted
        /// </summary>
        RejectedToBlacklist = 11,
        /// <summary>
        /// Message has been rejected due to an anti-flooding mechanism
        /// </summary>
        RejectedAntiFlood = 12,
        /// <summary>
        /// Message rejected due to an expected system error
        /// </summary>
        RejectedSystemError = 13,
        /// <summary>
        /// The phone number specified is invalid.
        /// </summary>
        InvalidPhoneNumber = 14,
        /// <summary>
        /// Message is rejected as you have not enough funds to send the message.
        /// </summary>
        RejectedInsufficientFunds = 15,
        /// <summary>
        /// Message is rejected as you have reached your maximum number of messages sent for today.
        /// </summary>
        RejectedDailyLimitReached = 16
    }
}
