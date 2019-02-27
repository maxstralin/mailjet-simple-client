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
        public MailjetEmailClient(IMailjetEmailOptions options) : base(new MailjetOptions
        {
            ApiVersion = (ApiVersion)options.ApiVersion,
            PrivateKey = options.PrivateKey,
            PublicKey = options.PublicKey
        })
        {
            //TODO: Implement EmailApiVersion.V3
            if (ApiVersion != EmailApiVersion.V3_1) throw new UnsupportedApiVersionException();
        }

        public new EmailApiVersion ApiVersion { get => (EmailApiVersion)base.ApiVersion; }
        private new IMailjetOptions MailjetOptions { get => base.MailjetOptions; }

        public IMailjetEmailOptions MailjetEmailOptions { get => MailjetOptions; }

        public async Task<IResponse<SendEmailResponse>> SendAsync(IEnumerable<IEmailMessage> emailMessages)
        {
            var res = await SendRequestAsync(new SendEmailRequest(emailMessages, MailjetEmailOptions));

            return res.WithData<SendEmailResponse>();
        }

        public Task<IResponse<SendEmailResponse>> SendAsync(IEmailMessage emailMessage)
        {
            return SendAsync(new[] { emailMessage });
        }
    }
}