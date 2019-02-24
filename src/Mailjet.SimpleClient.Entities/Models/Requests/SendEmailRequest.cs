using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Requests
{
    public class SendEmailRequest : BaseRequest
    {
        public SendEmailRequest(IEnumerable<IEmailMessage> emailMessages, IMailjetEmailOptions mailjetEmailOptions)
        {
            if (emailMessages == null)
            {
                throw new ArgumentNullException(nameof(emailMessages));
            }

            if (mailjetEmailOptions == null)
            {
                throw new ArgumentNullException(nameof(mailjetEmailOptions));
            }

            if (mailjetEmailOptions.ApiVersion != EmailApiVersion.V3_1) throw new UnsupportedApiVersionException();

            EmailApiVersion = mailjetEmailOptions.ApiVersion;
            PrivateKey = mailjetEmailOptions.PrivateKey;
            PublicKey = mailjetEmailOptions.PublicKey;
            var basicAuthValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{PublicKey}:{PrivateKey}"));
            AuthenticationHeaderValue = new AuthenticationHeaderValue("Basic", basicAuthValue);

            SetRequestBody(new { Messages = emailMessages });
        }
        public SendEmailRequest(IEmailMessage emailMessage, IMailjetEmailOptions mailjetEmailOptions) : this(new[] { emailMessage }, mailjetEmailOptions)
        {

        }

        public EmailApiVersion EmailApiVersion { get; }
        public string PrivateKey { get; }
        public string PublicKey { get; }
    }
}
