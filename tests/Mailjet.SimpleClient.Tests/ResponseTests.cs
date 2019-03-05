using Newtonsoft.Json;
using System.Collections.Generic;
using Mailjet.SimpleClient.Core.Models.Responses;
using Mailjet.SimpleClient.Core.Models.Responses.Emailing;
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
    }
}
