using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public enum EmailStatus
    {
        Unknown,
        Queued,
        Sent,
        Opened,
        Clicked,
        Bounce,
        Spam,
        Unsub,
        Blocked,
        Hardbounced,
        Softbounced,
        Deferred,
    }
}
