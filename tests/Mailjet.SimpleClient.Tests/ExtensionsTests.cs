using System.Collections.Generic;
using System.Linq;
using Mailjet.SimpleClient.Client;
using Mailjet.SimpleClient.Entities.Extensions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Responses;
using Mailjet.SimpleClient.Tests.Mocks;
using Mailjet.SimpleClient.Tests.Static;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void Test_ValidateDefaultDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddMailjetEmailClient(Config.MailjetEmailOptions);

            var serviceProvider = services.BuildServiceProvider();
            var resolvedOptions = serviceProvider.GetRequiredService<IMailjetEmailOptions>();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetEmailClient>();

            Assert.Equal(resolvedOptions, Config.MailjetEmailOptions);
            Assert.IsAssignableFrom<IMailjetEmailClient>(resolvedClient);
            Assert.IsType<MailjetEmailClient>(resolvedClient);
            Assert.NotNull(resolvedClient);
        }

        [Fact]
        public void Test_ValidateOptionsByActionDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddMailjetEmailClient((opt) => opt.PrivateKey = Config.MailjetEmailOptions.PrivateKey);

            var serviceProvider = services.BuildServiceProvider();
            var resolvedOptions = serviceProvider.GetRequiredService<IMailjetEmailOptions>();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetEmailClient>();

            Assert.Equal(resolvedOptions.PrivateKey, Config.MailjetEmailOptions.PrivateKey);
            Assert.IsAssignableFrom<IMailjetEmailClient>(resolvedClient);
            Assert.IsType<MailjetEmailClient>(resolvedClient);
            Assert.NotNull(resolvedClient);
        }

        [Fact]
        public void Test_ValidateCustomImplementationDependencyInjection()
        {
            var services = new ServiceCollection();
            services.AddMailjetEmailClient<MailjetEmailClientMock>();
            var serviceProvider = services.BuildServiceProvider();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetEmailClient>();

            Assert.IsAssignableFrom<IMailjetEmailClient>(resolvedClient);
            Assert.IsType<MailjetEmailClientMock>(resolvedClient);
            Assert.NotNull(resolvedClient);
        }

        [Fact]
        public void Test_ValidateGetEntriesForAllRecipients()
        {
            var expectedEmails = new[] {"to@test.com", "cc@test.com", "bcc@test.com"};
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
