using Mailjet.SimpleClient.Entities.Models.Emailing;
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
    }
}
