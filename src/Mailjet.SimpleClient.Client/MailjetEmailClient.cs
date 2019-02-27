using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Options;
using Mailjet.SimpleClient.Entities.Models.Requests;
using Mailjet.SimpleClient.Entities.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Client
{
    public class MailjetEmailClient : MailjetSimpleClient, IMailjetEmailClient<SendEmailResponse>
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

        public IMailjetEmailOptions Options { get; private set; } = null;

        public async Task<IResponse<SendEmailResponse>> SendAsync(IEnumerable<IEmailMessage> emailMessages)
        {
            var res = await SendRequestAsync(new SendEmailRequest(emailMessages, Options));

            return res.WithData<SendEmailResponse>();
        }

        public Task<IResponse<SendEmailResponse>> SendAsync(IEmailMessage emailMessage)
        {
            return SendAsync(new[] { emailMessage });
        }
    }
}