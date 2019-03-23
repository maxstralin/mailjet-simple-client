using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Mailjet.SimpleClient.Core.Models.Responses;
using Mailjet.SimpleClient.Core.Models.Responses.Emailing;
using Mailjet.SimpleClient.Core.Models.Responses.Sms;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class ResponseTests
    {
        [Fact]
        public void Test_ValidateDeserialisationToResponse()
        {
            var entry = new SendEmailResponseEntry()
            {
                To = new List<SendEmailResponseResult>() { new SendEmailResponseResult() { Email = "max" } },
                Status = "success"
            };

            var serialised = JsonConvert.SerializeObject(entry);
            var deserialised = JsonConvert.DeserializeObject<SendEmailResponseEntry>(serialised);
            var reserialised = JsonConvert.SerializeObject(deserialised);

            Assert.Equal(serialised, reserialised);

        }

        [Fact]
        public void Test_ValidateTimestampSendSmsResponseEntry()
        {
            var expectedCreation = DateTimeOffset.UtcNow;
            var expectedSent = DateTimeOffset.Now.AddDays(1);

            var entry = new SendSmsResponseEntry
            {
                CreationTs = expectedCreation.ToUnixTimeSeconds(),
                SentTs = expectedSent.ToUnixTimeSeconds()
            };

            Assert.Equal(expectedCreation.ToUnixTimeSeconds(), entry.CreationTs);
            Assert.Equal(expectedSent.ToUnixTimeSeconds(), entry.SentTs);

            Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(entry.CreationTs).UtcDateTime, entry.CreationTimestamp);
            Assert.Equal(DateTimeOffset.FromUnixTimeSeconds(entry.SentTs.Value).UtcDateTime, entry.SentTimestamp);
        }

    }
}
