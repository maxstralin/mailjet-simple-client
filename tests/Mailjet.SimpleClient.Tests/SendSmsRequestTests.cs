using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Core.Models.Sms;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class SendSmsRequestTests : ConfigurationFixture
    {
        [Fact]
        public void Test_AuthenticationHeaderSetCorrectly()
        {
            var expectedResult = MailjetOptions.Token;
            var scheme = "Bearer";

            var req = new SendSmsRequest(new SmsMessage(), MailjetOptions);

            Assert.True(req.AuthenticationHeaderValue.Scheme == scheme);
            Assert.True(req.AuthenticationHeaderValue.Parameter == expectedResult);
        }

        [Fact]
        public void Test_SendSmsRequestShouldNotAcceptNulls()
        {
            Assert.Throws<ArgumentNullException>(() => new SendSmsRequest( (ISmsMessage)null, MailjetOptions));
            Assert.Throws<ArgumentNullException>(() => new SendSmsRequest(new SmsMessage(), null));
        }

        [Fact]
        public void Test_ValidatePath()
        {
            var path = "v4/sms-send";
            var req = new SendSmsRequest(new SmsMessage(), MailjetOptions);
            Assert.Equal(path, req.Path);
        }

    }
}
