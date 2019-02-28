using Mailjet.SimpleClient.Entities.Interfaces;

// ReSharper disable NonReadonlyMemberInGetHashCode

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
        /// If only to validate the request but not actually send it. Defaults to false
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
            unchecked
            {
                var hashCode = (PublicKey != null ? PublicKey.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PrivateKey != null ? PrivateKey.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) ApiVersion;
                hashCode = (hashCode * 397) ^ SandboxMode.GetHashCode();
                return hashCode;
            }
        }
    }
}
