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
    public class MailjetEmailClient : IMailjetEmailClient
    {
        private readonly IMailjetSimpleClient client;

        public MailjetEmailClient(IMailjetSimpleClient client, IMailjetOptions options)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            Options = options ?? throw new ArgumentNullException(nameof(options));
            if (Options.EmailOptions.EmailApiVersion != EmailApiVersion.V3_1) throw new UnsupportedApiVersionException();
        }

        public IMailjetOptions Options { get; private set; }

        public async Task<ISendEmailResponse> SendAsync(IEnumerable<IEmailMessage> emailMessages)
        {
            var res = await client.SendRequestAsync(new SendEmailRequest(emailMessages, Options));
            return new SendEmailResponse(res.RawResponse["Messages"]?.ToObject<List<SendEmailResponseEntry>>(), res);
        }

        public Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage) => SendAsync(new[] {emailMessage});
    }
}