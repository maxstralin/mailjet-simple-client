using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Options
{
    public class MailjetOptions : IMailjetOptions
    {
        public MailjetOptions()
        {

        }

        public MailjetOptions(IMailjetEmailOptions mailjetEmailOptions)
        {
            if (mailjetEmailOptions == null)
            {
                throw new ArgumentNullException(nameof(mailjetEmailOptions));
            }

            PublicKey = mailjetEmailOptions.PublicKey;
            PrivateKey = mailjetEmailOptions.PublicKey;
            SandboxMode = mailjetEmailOptions.SandboxMode;
            ApiVersion = (ApiVersion)mailjetEmailOptions.ApiVersion;
        }

        public MailjetOptions(IMailjetSmsOptions mailjetSmsOptions)
        {
            if (mailjetSmsOptions == null)
            {
                throw new ArgumentNullException(nameof(mailjetSmsOptions));
            }

            PublicKey = mailjetSmsOptions.PublicKey;
            PrivateKey = mailjetSmsOptions.PublicKey;
            SandboxMode = mailjetSmsOptions.SandboxMode;
            ApiVersion = (ApiVersion)mailjetSmsOptions.ApiVersion;
        }

        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Token { get; set; }
        public ApiVersion ApiVersion { get; set; }
        public bool SandboxMode { get; set; } = false;

        EmailApiVersion IMailjetEmailOptions.ApiVersion { get => (EmailApiVersion)ApiVersion; set { ApiVersion = (ApiVersion)value; } }
    }
}
