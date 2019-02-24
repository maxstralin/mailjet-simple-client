using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models
{
    public class MailjetOptions : IMailjetOptions
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Token { get; set; }
        public ApiVersion ApiVersion { get; set; }
        EmailApiVersion IMailjetEmailOptions.ApiVersion { get => (EmailApiVersion)ApiVersion; set { ApiVersion = (ApiVersion)value; } }
    }
}
