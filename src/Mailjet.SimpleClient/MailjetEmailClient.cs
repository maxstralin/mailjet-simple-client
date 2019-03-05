using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Core.Models.Responses;
using Mailjet.SimpleClient.Core.Models.Responses.Emailing;
using Mailjet.SimpleClient.Core.Serialisers;
using Mailjet.SimpleClient.Logging;
using Newtonsoft.Json;

namespace Mailjet.SimpleClient
{
    public class MailjetEmailClient : IMailjetEmailClient
    {
        private readonly IMailjetSimpleClient client;
        private static readonly ILog Log = LogProvider.For<MailjetEmailClient>();

        public MailjetEmailClient(IMailjetSimpleClient client, IMailjetOptions options)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public IMailjetOptions Options { get; private set; }

        public async Task<ISendEmailResponse> SendAsync(IEnumerable<IEmailMessage> emailMessages)
        {
            try
            {
                var emails = emailMessages.ToList();
                Log.Info($"Sending {emails.Count} emails");
                Log.Debug("Email options: " + LogSerialiser.Serialise(Options.EmailOptions));
                var req = new SendEmailRequest(emails, Options);
                var res = await client.SendRequestAsync(req);

                return new SendEmailResponse(
                    res.RawResponse["Messages"]?.ToObject<List<SendEmailResponseEntry>>(),
                    res);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error sending emails");
                throw;
            }
        }

        public Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage) => SendAsync(new[] { emailMessage });
    }
}