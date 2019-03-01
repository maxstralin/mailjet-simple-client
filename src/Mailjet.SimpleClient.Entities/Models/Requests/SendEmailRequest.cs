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
        public IMailjetEmailOptions MailjetEmailOptions { get; }
        
        public SendEmailRequest(IEnumerable<IEmailMessage> emailMessages, IMailjetEmailOptions options)
        {
            if (emailMessages == null)
            {
                throw new ArgumentNullException(nameof(emailMessages));
            }

            MailjetEmailOptions = options ?? throw new ArgumentNullException(nameof(options));

            if (MailjetEmailOptions.ApiVersion != EmailApiVersion.V3_1) throw new UnsupportedApiVersionException();

            var messages = emailMessages.ToList();
            if (messages.Count == 0) throw new ArgumentException("There must be at least one message", nameof(emailMessages));

            AuthenticationHeaderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{MailjetEmailOptions.PublicKey}:{MailjetEmailOptions.PrivateKey}")));

            SetRequestBody(new { Messages = messages, options.SandboxMode });
            HttpMethod = new HttpMethod("POST");
            Path = "v3.1/send";
        }
        public SendEmailRequest(IEmailMessage emailMessage, IMailjetEmailOptions mailjetEmailOptions) : this(new[] { emailMessage }, mailjetEmailOptions)
        {

        }
    }
}
