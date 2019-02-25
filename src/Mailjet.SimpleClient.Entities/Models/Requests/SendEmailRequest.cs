using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Requests
{
    public class SendEmailRequest : BaseRequest
    {
        public IMailjetEmailOptions MailjetEmailOptions { get; } = new MailjetEmailOptions();
        
        public SendEmailRequest(IEnumerable<IEmailMessage> emailMessages, IMailjetEmailOptions options)
        {
            if (emailMessages == null)
            {
                throw new ArgumentNullException(nameof(emailMessages));
            }
            MailjetEmailOptions = options ?? throw new ArgumentNullException(nameof(options));
            if (MailjetEmailOptions.ApiVersion != EmailApiVersion.V3_1) throw new UnsupportedApiVersionException();
            if (!emailMessages.Any()) throw new ArgumentException("There must be at least one message", nameof(emailMessages));

            AuthenticationHeaderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{MailjetEmailOptions.PublicKey}:{MailjetEmailOptions.PrivateKey}")));

            SetRequestBody(new { Messages = emailMessages });
            HttpMethod = new HttpMethod("POST");
            Path = "V3.1/send";
        }
        public SendEmailRequest(IEmailMessage emailMessage, IMailjetEmailOptions mailjetEmailOptions) : this(new[] { emailMessage }, mailjetEmailOptions)
        {

        }
    }
}
