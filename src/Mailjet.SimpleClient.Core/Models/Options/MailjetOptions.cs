using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Options
{
    public class MailjetOptions : IMailjetOptions
    {
        public IMailjetEmailOptions EmailOptions { get; } = new MailjetEmailOptions();
        public IMailjetSmsOptions SmsOptions { get; set; } = new MailjetSmsOptions();
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Token { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected bool Equals(MailjetOptions other)
        {
            return Equals(EmailOptions, other.EmailOptions) && Equals(SmsOptions, other.SmsOptions) && string.Equals(PublicKey, other.PublicKey) && string.Equals(PrivateKey, other.PrivateKey) && string.Equals(Token, other.Token);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (EmailOptions != null ? EmailOptions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SmsOptions != null ? SmsOptions.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PublicKey != null ? PublicKey.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PrivateKey != null ? PrivateKey.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Token != null ? Token.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
