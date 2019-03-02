using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Tests.Static;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class MailjetEmailClientTest
    {
        private readonly IMailjetEmailOptions mailjetEmailOptions;
        public MailjetEmailClientTest()
        {
            mailjetEmailOptions = Config.GetMailjetEmailOptions();
        }
        [Fact]
        public void Test_ValidateOptionsInstance()
        {
            var client = new MailjetEmailClient(mailjetEmailOptions);
            
            
            Assert.Same(mailjetEmailOptions, client.Options);
            Assert.Equal(mailjetEmailOptions, client.Options);
        }

        [Fact]
        public void Test_ValidateOptionsProperties()
        {
            var client = new MailjetEmailClient((opt) =>
            {
                opt.PrivateKey = mailjetEmailOptions.PrivateKey;
                opt.PublicKey = mailjetEmailOptions.PublicKey;
                opt.SandboxMode = mailjetEmailOptions.SandboxMode;
                opt.ApiVersion = mailjetEmailOptions.ApiVersion;
            });

            Assert.NotSame(mailjetEmailOptions, client.Options);
            Assert.Equal(mailjetEmailOptions, client.Options);
        }

        [Fact]
        public void Test_V3_1DefaultInMailjetEmailOptions()
        {
            var apiVersion = EmailApiVersion.V3_1;
            var options = new MailjetEmailOptions();
            Assert.Equal(options.ApiVersion, apiVersion);
        }

        [Fact]
        public void Test_OnlyV3_1Supported()
        {
            mailjetEmailOptions.ApiVersion = EmailApiVersion.V3;
            Assert.Throws<UnsupportedApiVersionException>(() => new MailjetEmailClient(mailjetEmailOptions));
        }
    }
}
