﻿namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendEmailResponseResult
    {
        string Email { get; set; }
        string MessageHref { get; set; }
        long MessageId { get; set; }
        string MessageUuid { get; set; }
    }
}