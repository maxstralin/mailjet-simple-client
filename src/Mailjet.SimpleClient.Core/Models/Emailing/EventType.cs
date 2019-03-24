using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public enum EventType
    {
        Sent,
        Opened,
        Clicked,
        Bounced,
        Blocked,
        Unsub,
        Spam
    }
}
