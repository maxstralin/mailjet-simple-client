using Mailjet.SimpleClient.Client;
using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Requests;
using Mailjet.SimpleClient.Entities.Resolvers;
using Moq;
using Moq.Protected;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class MailjetEmailClientTest
    {
        private readonly IMailjetEmailOptions options = new MailjetEmailOptions
        {
            ApiVersion = EmailApiVersion.V3_1,
            PrivateKey = "Max",
            PublicKey = "Str�lin"
        };

        [Fact]
        public void Test_OnlyV3_1Supported()
        {
            options.ApiVersion = EmailApiVersion.V3;
            Assert.Throws<UnsupportedApiVersionException>(() => new MailjetEmailClient(options));
            Assert.Throws<UnsupportedApiVersionException>(() => new SendEmailRequest(new EmailMessage(), options));
        }

        [Fact]
        public void Test_MessagesAreAlwaysInArray()
        {
            var msg = new EmailMessage();
            var singleMessageInArray = new SendEmailRequest(new[] { msg }, options);
            var twoMessages = new SendEmailRequest(new[] { msg, msg }, options);
            var singleMessage = new SendEmailRequest(msg, options);

            Assert.True(singleMessageInArray.RequestBody["Messages"].Type == JTokenType.Array);
            Assert.True(twoMessages.RequestBody["Messages"].Type == JTokenType.Array);
            Assert.True(singleMessage.RequestBody["Messages"].Type == JTokenType.Array);

            Assert.True(singleMessageInArray.RequestBody["Messages"].Children().Count() == 1);
            Assert.True(twoMessages.RequestBody["Messages"].Children().Count() == 2);
            Assert.True(singleMessage.RequestBody["Messages"].Children().Count() == 1);

        }

        [Fact]
        public void Test_AuthenicationHeaderSetCorrectly()
        {
            var msg = new EmailMessage();
            var expectedResult = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{options.PublicKey}:{options.PrivateKey}"));
            var scheme = "Basic";

            var req = new SendEmailRequest(new[] { msg }, options);

            Assert.True(req.AuthenticationHeaderValue.Scheme == scheme);
            Assert.True(req.AuthenticationHeaderValue.Parameter == expectedResult);
        }

        [Fact]
        public void Test_IgnoreSerialisingNullValues()
        {
            var msg = new EmailMessage();
            var req = new SendEmailRequest(new[] { msg }, options);
            Assert.Null(msg.Id);
            //Note that if the value doesn't exit, it returns null. If the value exists, it return a JValue with the value of null!
            Assert.Null(req.RequestBody["Messages"].First[nameof(msg.Id)]);
        }
    }
}
