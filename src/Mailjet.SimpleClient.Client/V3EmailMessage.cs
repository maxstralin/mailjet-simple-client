using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Client
{
    class V3EmailMessage
    {
        string FromEmail { get; set; }
        string FromName { get; set; }
        string Sender { get; set; }
        string To { get; set; }

    }
}
