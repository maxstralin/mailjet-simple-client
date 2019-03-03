using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;

namespace Mailjet.SimpleClient.Core.Models.Requests
{
    public class SendEmailRequest : BaseRequest
    {
        public SendEmailRequest(IEnumerable<IEmailMessage> emailMessages, IMailjetOptions options)
        {
            if (emailMessages == null)
            {
                throw new ArgumentNullException(nameof(emailMessages));
            }

            Options = options ?? throw new ArgumentNullException(nameof(options));

            if (Options.EmailOptions.EmailApiVersion != EmailApiVersion.V3_1) throw new UnsupportedApiVersionException();

            var messages = emailMessages.ToList();
            if (messages.Count == 0) throw new ArgumentException("There must be at least one message", nameof(emailMessages));

            AuthenticationHeaderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{options.PublicKey}:{options.PrivateKey}")));
            SetRequestBody(new { Messages = messages, options.EmailOptions.SandboxMode });
            HttpMethod = new HttpMethod("POST");
            Path = "v3.1/send";
        }
        public SendEmailRequest(IEmailMessage emailMessage, IMailjetOptions options) : this(new[] { emailMessage }, options)
        {

        }

        public IMailjetOptions Options { get; }

    }
}
