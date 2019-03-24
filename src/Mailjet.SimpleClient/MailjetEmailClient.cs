using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Abstracts;
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
    /// <summary>
    /// A client for interacting with Mailjet for the purpose of sending emails
    /// </summary>
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
                    res.ParsedResponse["Messages"]?.ToObject<List<SendEmailResponseEntry>>(),
                    res);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error sending emails");
                throw;
            }
        }

        public Task<ISendEmailResponse> SendAsync(IEmailMessage emailMessage) => SendAsync(new[] { emailMessage });

        public async Task<IGetMessagesResponse> GetMessagesAsync(IGetMessagesFilters messageFilters)
        {
            var res = await client.SendRequestAsync(new GetEmailsRequest(Options, messageFilters));
            var data = res.ParsedResponse.ToObject<RetrieveDetailsResponse<IEnumerable<IMessageDetails>>>(
                new JsonSerializer
                {
                    Converters = { new InterfaceJsonConverter<IMessageDetails, MessageDetails>() }
                }
                );

            return new GetMessagesResponse(data, res.RawResponse, res.StatusCode, res.Successful);
        }

        public async Task<IGetMessageResponse> GetMessageAsync(long messageId)
        {
            var res = await client.SendRequestAsync(new GetEmailRequest(Options, messageId));

            var originalData = res.ParsedResponse.ToObject<RetrieveDetailsResponse<IEnumerable<IMessageDetails>>>(
                new JsonSerializer
                {
                    Converters = { new InterfaceJsonConverter<IMessageDetails, MessageDetails>() }
                }
            );
            //API returns an array, even if this will always be a single entry. Let's normalise that result into just a single entry
            var data = new RetrieveDetailsResponse<IMessageDetails>
            {
                Data = originalData.Data?.SingleOrDefault(),
                Count = originalData.Count,
                Total = originalData.Total
            };

            return new GetMessageResponse(data, res.RawResponse, res.StatusCode, res.Successful);
        }

        public async Task<IGetMessageHistoryResponse> GetMessageHistoryAsync(long messageId)
        {
            var res = await client.SendRequestAsync(new GetMessageHistoryRequest(Options, messageId));

            var data = res.ParsedResponse.ToObject<RetrieveDetailsResponse<IEnumerable<IMessageHistory>>>(
                new JsonSerializer
                {
                    Converters = { new InterfaceJsonConverter<IMessageHistory, MessageHistory>() }
                }
            );

            return new GetMessageHistoryResponse(data, res.RawResponse, res.StatusCode, res.Successful);
        }

        public async Task<IResponse<IRetrieveDetailsResponse<IEnumerable<IMessageInformation>>>> GetMessageInformationAsync(IGetMessagesFilters messageFilters)
        {
            var res = await client.SendRequestAsync(new GetMessagesInformationRequest(Options, messageFilters));

            var data = res.ParsedResponse.ToObject<IRetrieveDetailsResponse<IEnumerable<IMessageInformation>>>(
                new JsonSerializer
                {
                    Converters = { new InterfaceJsonConverter<IMessageInformation, MessageInformation>() }
                }
            );

            return new ResponseBase<IRetrieveDetailsResponse<IEnumerable<IMessageInformation>>>(data, res.RawResponse, res.StatusCode, res.Successful);
        }

        public Task<IResponse<IRetrieveDetailsResponse<IMessageInformation>>> GetMessageInformationAsync(long messageId)
        {
            throw new NotImplementedException();
        }
    }
}