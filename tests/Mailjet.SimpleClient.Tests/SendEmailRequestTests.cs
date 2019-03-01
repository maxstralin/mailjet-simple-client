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
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class RequestTests
    {
        //TODO: Should probably be moved into a TestFixture or something since now it's a bit wet... (not DRY)
        private readonly IMailjetEmailOptions options = new MailjetEmailOptions
        {
            ApiVersion = EmailApiVersion.V3_1,
            PrivateKey = "Max",
            PublicKey = "Strålin"
        };

        [Fact]
        public void Test_OnlyV3_1Supported()
        {
            options.ApiVersion = EmailApiVersion.V3;
            // ReSharper disable once ObjectCreationAsStatement
            void Action() => new SendEmailRequest(new EmailMessage("Test", "dummy@test.dev"), options);
            Assert.Throws<UnsupportedApiVersionException>((Action) Action);
        }

        [Fact]
        public void Test_MessagesAreAlwaysInArray()
        {
            var msg = new EmailMessage("Test", "dummy@test.dev");
            var singleMessageInArray = new SendEmailRequest(new[] { msg }, options);
            var twoMessages = new SendEmailRequest(new[] { msg, msg }, options);
            var singleMessage = new SendEmailRequest(msg, options);

            Assert.True(singleMessageInArray.RequestBody["Messages"].Type == JTokenType.Array);
            Assert.True(twoMessages.RequestBody["Messages"].Type == JTokenType.Array);
            Assert.True(singleMessage.RequestBody["Messages"].Type == JTokenType.Array);
        }

        [Fact]
        public void Test_ValidateMessageCountInRequest()
        {
            var msg = new EmailMessage("Test", "dummy@test.dev");
            var singleMessageInArray = new SendEmailRequest(new[] { msg }, options);
            var twoMessages = new SendEmailRequest(new[] { msg, msg }, options);
            var singleMessage = new SendEmailRequest(msg, options);

            Assert.True(singleMessageInArray.RequestBody["Messages"].Children().Count() == 1);
            Assert.True(twoMessages.RequestBody["Messages"].Children().Count() == 2);
            Assert.True(singleMessage.RequestBody["Messages"].Children().Count() == 1);
        }

        [Fact]
        public void Test_AuthenicationHeaderSetCorrectly()
        {
            var msg = new EmailMessage("Test", "dummy@test.dev");
            var expectedResult = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{options.PublicKey}:{options.PrivateKey}"));
            var scheme = "Basic";

            var req = new SendEmailRequest(new[] { msg }, options);

            Assert.True(req.AuthenticationHeaderValue.Scheme == scheme);
            Assert.True(req.AuthenticationHeaderValue.Parameter == expectedResult);
        }

        [Fact]
        public void Test_IgnoreSerialisingNullValues()
        {
            var msg = new EmailMessage("Test", "dummy@test.dev");
            var req = new SendEmailRequest(new[] { msg }, options);
            Assert.Null(msg.Id);
            //Note that if the value doesn't exit, it returns null. If the value exists, it return a JValue with the value of null!
            Assert.Null(req.RequestBody["Messages"].First[nameof(msg.Id)]);
        }

        [Fact]
        public void Test_SendEmailRequestShouldNotAcceptNulls()
        {
            Assert.Throws<ArgumentNullException>(() => new SendEmailRequest((IEnumerable<IEmailMessage>)null, options));
            Assert.Throws<ArgumentNullException>(() => new SendEmailRequest(Enumerable.Empty<IEmailMessage>(), null));
        }

        [Fact]
        public void Test_SendEmailRequestShouldNotEmptyArray()
        {
            Assert.Throws<ArgumentException>(() => new SendEmailRequest(Enumerable.Empty<IEmailMessage>(), options));
        }

        [Fact]
        public void Test_ValidatePath()
        {
            var path = "v3.1/send";
            var req = new SendEmailRequest(new EmailMessage("Test", "dummy@test.dev"), options);
            Assert.Equal(path, req.Path);
        }

    }
}
