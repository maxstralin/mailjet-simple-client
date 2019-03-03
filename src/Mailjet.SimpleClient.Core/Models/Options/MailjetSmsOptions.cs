using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Options
{
    public class MailjetSmsOptions : IMailjetSmsOptions
    {
        public SmsApiVersion SmsApiVersion { get; set; } = SmsApiVersion.V4;
    }
}
