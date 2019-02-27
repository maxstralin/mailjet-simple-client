using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Options
{
    public class MailjetEmailOptions : IMailjetEmailOptions
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        /// <summary>
        /// Defaults to 3.1
        /// </summary>
        public EmailApiVersion ApiVersion { get; set; } = EmailApiVersion.V3_1;
        /// <summary>
        /// If only to validate the request but not actually send it. Defaults to fale
        /// </summary>
        public bool SandboxMode { get; set; } = false;

        public override bool Equals(object obj)
        {
            return obj is MailjetEmailOptions options &&
                   PublicKey == options.PublicKey &&
                   PrivateKey == options.PrivateKey &&
                   ApiVersion == options.ApiVersion &&
                   SandboxMode == options.SandboxMode;
        }

        public override int GetHashCode()
        {
            var hashCode = 1653785258;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PublicKey);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PrivateKey);
            hashCode = hashCode * -1521134295 + ApiVersion.GetHashCode();
            hashCode = hashCode * -1521134295 + SandboxMode.GetHashCode();
            return hashCode;
        }
    }
}
