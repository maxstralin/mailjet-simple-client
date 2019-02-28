using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Options;
using Mailjet.SimpleClient.Entities.Models.Requests;
using Mailjet.SimpleClient.Entities.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Client
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
            return new SendEmailResponse(res.RawResponse["Messages"].ToObject<List<SendEmailResponseEntry>>(), res);
        }

        public Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage)
        {
            return SendAsync(new[] { emailMessage });
        }
    }
}