using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Core.Models.Responses;

namespace Mailjet.SimpleClient
{
    public class MailjetEmailClient : MailjetSimpleClient, IMailjetEmailClient
    {
        public MailjetEmailClient(Action<IMailjetEmailOptions> options)
        {
            SetOptions(new MailjetEmailOptions());
            options(Options);
        }

        public MailjetEmailClient(IMailjetEmailOptions options)
        {
            SetOptions(options);
        }

        private void SetOptions(IMailjetEmailOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
            if (Options.ApiVersion != EmailApiVersion.V3_1) throw new UnsupportedApiVersionException();
        }

        public IMailjetEmailOptions Options { get; private set; }

        public async Task<ISendEmailResponse> SendAsync(IEnumerable<IEmailMessage> emailMessages)
        {
            var res = await SendRequestAsync(new SendEmailRequest(emailMessages, Options));
            return new SendEmailResponse(res.RawResponse["Messages"]?.ToObject<List<SendEmailResponseEntry>>(), res);
        }

        public Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage)
        {
            return SendAsync(new[] { emailMessage });
        }
    }
}