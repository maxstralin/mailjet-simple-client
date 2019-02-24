using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models
{
    public class MailjetEmailOptions : IMailjetEmailOptions
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        /// <summary>
        /// Defaults to 3.1
        /// </summary>
        public EmailApiVersion ApiVersion { get; set; } = EmailApiVersion.V3_1;
    }
}
