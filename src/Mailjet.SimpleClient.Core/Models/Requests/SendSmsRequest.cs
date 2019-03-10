using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;

namespace Mailjet.SimpleClient.Core.Models.Requests
{
    public class SendSmsRequest : RequestBase
    {
        private readonly IMailjetOptions options;

        public SendSmsRequest(ISmsMessage smsMessage, IMailjetOptions options)
        {
            if (smsMessage == null) throw new ArgumentNullException(nameof(smsMessage));
            this.options = options ?? throw new ArgumentNullException(nameof(options));

            if (options.SmsOptions.SmsApiVersion != SmsApiVersion.V4) throw new UnsupportedApiVersionException();

            AuthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", options.Token);
            SetRequestBody(smsMessage);
            HttpMethod = new HttpMethod("POST");
            Path = "v4/sms-send";
        }
    }
}
