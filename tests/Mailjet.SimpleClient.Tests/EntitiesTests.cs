using System;
using System.Collections.Generic;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Models.Responses.Emailing;
using Mailjet.SimpleClient.Core.Serialisers;
using Mailjet.SimpleClient.Tests.Mocks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class EntitiesTests
    {
        [Fact]
        public void Test_ParseStringIntoEmailEntity()
        {
            var name = "Person Personsson";
            var email = "person@personsson.com";
            var validEntity = EmailEntity.Parse($"{name} <{email}>");
            var invalidEntity = EmailEntity.Parse("invalid");

            Assert.Null(invalidEntity);
            Assert.IsType<EmailEntity>(validEntity);
            Assert.True(validEntity.Email == email);
            Assert.True(validEntity.Name == name);
        }

        [Fact]
        public void Test_SerialiseUrlTagsOfBaseEmailMessage()
        {
            var propertyName = "URLTags";
            var emailWithUrlTags = new BaseEmailMessageMock()
            {
                UrlTags = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("test", "true"),
                    new KeyValuePair<string, string>("cool", "false")
                }
            };
            var emailWithoutUrlTags = new BaseEmailMessageMock();

            var serialisedWithTags = MailjetSerialiser.Serialise(emailWithUrlTags);
            var serialisedWithoutTags = MailjetSerialiser.Serialise(emailWithoutUrlTags);

            Assert.Equal("test=true&cool=false", serialisedWithTags.Value<string>(propertyName));
            Assert.Null(serialisedWithoutTags.Value<string>(propertyName));
        }

        [Fact]
        public void Test_CreateQueryParamsForMessageFilters()
        {
            var filter = new GetMessagesFilters()
            {
                CampaignId = 1,
                FromType = EmailType.Marketing,
                ToTimestamp = new DateTime(2019,03,10, 17,00,00)
            };

            var queryString = filter.CreateQueryParamsString();

            Assert.Equal("campaign=1&fromType=2&ToTs=2019-03-10T17:00:00", queryString, StringComparer.CurrentCultureIgnoreCase);
        }

        [Fact]
        public void Test_EmailStatusEnumDeserialisation()
        {
            var json = new JObject
            {
                {"status", JToken.FromObject("hardbounced")}
            };
            var expected = new MessageDetails
            {
                Status = EmailStatus.Hardbounced
            };

            var actual = JsonConvert.DeserializeObject<MessageDetails>(json.ToString());

            Assert.Equal(expected.Status, actual.Status);
        }

    }
}
