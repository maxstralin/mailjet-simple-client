using Mailjet.SimpleClient.Client;
using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Models.Options;
using Mailjet.SimpleClient.Tests.Static;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class MailjetEmailClientTest
    {
        [Fact]
        public void Test_ValidateOptionsInstance()
        {
            var client = new MailjetEmailClient(Config.MailjetEmailOptions);
            
            
            Assert.Same(Config.MailjetEmailOptions, client.Options);
            Assert.Equal(Config.MailjetEmailOptions, client.Options);
        }

        [Fact]
        public void Test_ValidateOptionsProperties()
        {
            var client = new MailjetEmailClient((opt) =>
            {
                opt.PrivateKey = Config.MailjetEmailOptions.PrivateKey;
                opt.PublicKey = Config.MailjetEmailOptions.PublicKey;
                opt.SandboxMode = Config.MailjetEmailOptions.SandboxMode;
                opt.ApiVersion = Config.MailjetEmailOptions.ApiVersion;
            });

            Assert.NotSame(Config.MailjetEmailOptions, client.Options);
            Assert.Equal(Config.MailjetEmailOptions, client.Options);
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
            Config.MailjetEmailOptions.ApiVersion = EmailApiVersion.V3;
            Assert.Throws<UnsupportedApiVersionException>(() => new MailjetEmailClient(Config.MailjetEmailOptions));
        }
    }
}
