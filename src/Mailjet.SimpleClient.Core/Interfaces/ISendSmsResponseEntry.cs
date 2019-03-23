using System;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendSmsResponseEntry
    {
        string From { get; set; }
        string To { get; set; }
        string Text { get; set; }
        int MessageId { get; set; }
        int SmsCount { get; set; }
        long CreationTs { get; set; }
        DateTime CreationTimestamp { get; }
        long? SentTs { get; set; }
        DateTime? SentTimestamp { get; }
        ISendSmsCost Cost { get; set; }
        ISendSmsStatus Status { get; set; }
    }
}