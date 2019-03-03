using System.Collections.Generic;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Serialisers;
using Mailjet.SimpleClient.Tests.Mocks;
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
    }
}
