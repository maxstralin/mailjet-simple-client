using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Converters;
using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Core.Models.Responses;
using Mailjet.SimpleClient.Core.Models.Responses.Emailing;
using Mailjet.SimpleClient.Core.Serialisers;
using Mailjet.SimpleClient.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

                var token = JToken.Parse(res.RawResponse);

                return new SendEmailResponse(
                    token["Messages"]?.ToObject<List<SendEmailResponseEntry>>(),
                    res);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error sending emails");
                throw;
            }
        }

        public Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage) => SendAsync(new[] { emailMessage });

        public async Task<IGetMessagesResponse> GetMessagesAsync(IQueryFilter queryFilter)
        {
            var res = await client.SendRequestAsync(new GetEmailsRequest(Options, queryFilter));
            var data = res.ParsedResponse.ToObject<RetrieveDetailsResponse<IGetMessagesResponseEntry>>(
                new JsonSerializer
                {
                    Converters = { new InterfaceJsonConverter<IGetMessagesResponseEntry, GetMessagesResponseEntry>() }
                }
                );

            return new GetMessagesResponse(data, res.RawResponse, res.StatusCode, res.Successful);
        }

        public async Task<IResponse> GetMessageAsync(int messageId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse> GetMessageHistoryAsync(int messageId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse> GetMessageHistoryAsync(IQueryFilter queryFilter)
        {
            throw new NotImplementedException();
        }
    }
}