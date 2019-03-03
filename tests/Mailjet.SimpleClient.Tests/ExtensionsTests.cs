using System;
using System.Collections.Generic;
using System.Linq;
using Mailjet.SimpleClient.Core.Extensions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Core.Models.Responses;
using Mailjet.SimpleClient.Extensions;
using Mailjet.SimpleClient.Tests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class ExtensionsTests : ConfigurationFixture
    {
        [Fact]
        public void Test_ValidateDICustomEmailClient()
        {
            var services = new ServiceCollection();
            services.AddMailjetEmailClient<MailjetEmailClientMock>();

            Assert.Contains(services, descriptor => descriptor.ServiceType == typeof(IMailjetEmailClient) && descriptor.ImplementationType == typeof(MailjetEmailClientMock));
        }

        [Fact]
        public void Test_ValidateDIMailjetClients()
        {
            var services = new ServiceCollection();
            services.AddMailjetClients(a => a.PrivateKey = MailjetOptions.PrivateKey);

            var provider = services.BuildServiceProvider();
            var emailClient = provider.GetRequiredService<IMailjetEmailClient>();
            var simpleClient = provider.GetRequiredService<IMailjetSimpleClient>();
            var options = provider.GetRequiredService<IMailjetOptions>();

            Assert.IsType<MailjetEmailClient>(emailClient);
            Assert.IsType<MailjetSimpleClient>(simpleClient);
            Assert.IsType<MailjetOptions>(options);
        }

        [Fact]
        public void Test_ValidateSimpleClientCustomImplementationDependencyInjection()
        {
            var services = new ServiceCollection();
            services.AddMailjetSimpleClient<MailjetSimpleClientMock>();
            var serviceProvider = services.BuildServiceProvider();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetSimpleClient>();

            Assert.IsAssignableFrom<IMailjetSimpleClient>(resolvedClient);
            Assert.IsType<MailjetSimpleClientMock>(resolvedClient);
            Assert.NotNull(resolvedClient);
        }

        [Fact]
        public void Test_ValidateGetEntriesForAllRecipients()
        {
            var expectedEmails = new[] { "to@test.com", "cc@test.com", "bcc@test.com" };
            var entry = new SendEmailResponseEntry()
            {
                To = new List<ISendEmailResponseResult>() { new SendEmailResponseResult() { Email = "to@test.com" } },
                Cc = new List<ISendEmailResponseResult>() { new SendEmailResponseResult() { Email = "cc@test.com" } },
                Bcc = new List<ISendEmailResponseResult>() { new SendEmailResponseResult() { Email = "bcc@test.com" } }
            };

            var entries = entry.GetEntriesForAllRecipients();
            var actualEmails = entries.Select(a => a.Email);

            Assert.Equal(expectedEmails, actualEmails);
        }

    }
}
