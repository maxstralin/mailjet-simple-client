using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class ConfigurationTests : ConfigurationFixture
    {
        [Fact]
        public void Test_PublicAndPrivateKeyEnvVariableSet()
        {
            Assert.NotNull(Environment.GetEnvironmentVariable("MAILJET_PUBLIC_KEY"));
            Assert.NotNull(Environment.GetEnvironmentVariable("MAILJET_PRIVATE_KEY"));
        }
    }
}
