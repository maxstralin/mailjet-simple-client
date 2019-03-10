using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Core.Models.Responses.Sms;
using Mailjet.SimpleClient.Core.Models.Sms;
using Mailjet.SimpleClient.Core.Serialisers;
using Moq;
using Moq.Protected;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class MailjetSmsClientTests : ConfigurationFixture
    {
        [Fact]
        public void Test_ThrowIfNoBearerTokenSet()
        {
            var options = MailjetOptions;
            var simpleClient = new MailjetSimpleClient();

            options.Token = null;
            void Action() => new MailjetSmsClient(simpleClient, options);

            Assert.Throws<ArgumentException>((Action)Action);
        }

        //TODO: Could need some cleaning up
        [Fact]
        public async Task Test_SendSmsAsync()
        {
            var methodName = "SendAsync";
            var smsMessage = new SmsMessage();
            var testUri = "https://api.mailjet.com/v4/sms-send";
            var options = MailjetOptions;
            var entry = new SendSmsResponseEntry
            {
                CreationTs = DateTimeOffset.Now.ToUnixTimeSeconds(),
                SentTs = DateTimeOffset.Now.ToUnixTimeSeconds(),
                From = "Test SMS",
                Cost = new SendSmsCost
                {
                    Value = 123.321,
                    Currency = "EUR"
                },
                Status = new SendSmsStatus
                {
                    SmsStatus = (SmsStatus)2
                }
            };
            var smsResponse = new SendSmsResponse(entry, MailjetSerialiser.Serialise(entry).ToString(), 200, true);

            var httpResponse = new HttpResponseMessage((HttpStatusCode)smsResponse.StatusCode)
            {
                Content = new StringContent(smsResponse.RawResponse.ToString())
            };
            var messageHandler = new Mock<HttpMessageHandler>();
            messageHandler.Protected().Setup<Task<HttpResponseMessage>>(methodName,
                ItExpr.Is<HttpRequestMessage>(a => a.RequestUri.ToString() == testUri),
                ItExpr.IsAny<CancellationToken>()).Returns(Task.FromResult(httpResponse));

            var httpClient = new HttpClient(messageHandler.Object);
            var simpleClient = new MailjetSimpleClient();
            simpleClient.UseHttpClient(httpClient);
            options.Token = "SomeToken";
            var smsClient = new MailjetSmsClient(simpleClient, options);

            var res = await smsClient.SendAsync(new []{ smsMessage, smsMessage});
            
            Assert.All(res, response =>
            {
                Assert.Equal(entry.CreationTs, response.Data.CreationTs);
            });

        }
    }
}
