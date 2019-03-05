using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Core.Models.Responses.Sms;
using Mailjet.SimpleClient.Core.Serialisers;
using Mailjet.SimpleClient.Logging;

namespace Mailjet.SimpleClient
{
    public class MailjetSmsClient
    {
        private readonly IMailjetSimpleClient client;
        private readonly IMailjetOptions options;
        private static readonly ILog Log = LogProvider.For<MailjetSmsClient>();

        public MailjetSmsClient(IMailjetSimpleClient client, IMailjetOptions options)
        {
            this.client = client;
            this.options = options;
        }

        public async Task<ISendSmsResponse> SendAsync(ISmsMessage smsMessage)
        {
            Log.Info("Sending an SMS");
            Log.Debug("SMS options: " + LogSerialiser.Serialise(options.SmsOptions));
            var response = await client.SendRequestAsync(new SendSmsRequest(smsMessage, options));
            return new SendSmsResponse(response.RawResponse.ToObject<SendSmsResponseEntry>(), response.RawResponse,
                response.StatusCode, response.Successful);
        }

        public async Task<IEnumerable<ISendSmsResponse>> SendAsync(IEnumerable<ISmsMessage> smsMessages)
        {
            var tasks = smsMessages.Select(SendAsync).ToList();
            Log.Info($"Sending {tasks.Count} SMS");
            return await Task.WhenAll(tasks);
        }

    }
}
