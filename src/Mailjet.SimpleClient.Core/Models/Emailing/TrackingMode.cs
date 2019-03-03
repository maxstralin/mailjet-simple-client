using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public struct TrackingMode
    {
        public string AccountDefault => "account_default";
        public string Disabled => "disabled";
        public string Enabled => "enabled";
    }
}
