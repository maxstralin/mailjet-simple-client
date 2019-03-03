using Mailjet.SimpleClient.Core.Interfaces;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace Mailjet.SimpleClient.Core.Models.Options
{
    public class MailjetEmailOptions : IMailjetEmailOptions
    {
        /// <inheritdoc />
        public EmailApiVersion EmailApiVersion { get; set; } = EmailApiVersion.V3_1;

        /// <inheritdoc />
        public bool SandboxMode { get; set; } = false;

        public override bool Equals(object obj)
        {
            return obj is MailjetEmailOptions options &&
                   EmailApiVersion == options.EmailApiVersion &&
                   SandboxMode == options.SandboxMode;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) EmailApiVersion;
                hashCode = (hashCode * 397) ^ SandboxMode.GetHashCode();
                return hashCode;
            }
        }
    }
}
