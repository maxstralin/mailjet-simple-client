using System.Collections.Generic;
using System.Linq;
using Mailjet.SimpleClient.Core.Extensions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Responses;
using Mailjet.SimpleClient.Extensions;
using Mailjet.SimpleClient.Tests.Mocks;
using Mailjet.SimpleClient.Tests.Static;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void Test_ValidateEmailClientDefaultDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddMailjetEmailClient(Config.GetMailjetEmailOptions());

            var serviceProvider = services.BuildServiceProvider();
            var resolvedOptions = serviceProvider.GetRequiredService<IMailjetEmailOptions>();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetEmailClient>();

            Assert.Equal(resolvedOptions, Config.GetMailjetEmailOptions());
            Assert.IsAssignableFrom<IMailjetEmailClient>(resolvedClient);
            Assert.IsType<MailjetEmailClient>(resolvedClient);
            Assert.NotNull(resolvedClient);
        }

        [Fact]
        public void Test_ValidateEmailClientOptionsByActionDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddMailjetEmailClient((opt) => opt.PrivateKey = Config.GetMailjetEmailOptions().PrivateKey);

            var serviceProvider = services.BuildServiceProvider();
            var resolvedOptions = serviceProvider.GetRequiredService<IMailjetEmailOptions>();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetEmailClient>();

            Assert.Equal(resolvedOptions.PrivateKey, Config.GetMailjetEmailOptions().PrivateKey);
            Assert.IsAssignableFrom<IMailjetEmailClient>(resolvedClient);
            Assert.IsType<MailjetEmailClient>(resolvedClient);
            Assert.NotNull(resolvedClient);
        }

        [Fact]
        public void Test_ValidateEmailClientCustomImplementationDependencyInjection()
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
        public void Test_ValidateSimpleClientDependencyInjection()
        {
            var services = new ServiceCollection();
            services.AddMailjetSimpleClient<MailjetSimpleClient>();
            var serviceProvider = services.BuildServiceProvider();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetSimpleClient>();

            Assert.IsAssignableFrom<IMailjetSimpleClient>(resolvedClient);
            Assert.IsType<MailjetSimpleClient>(resolvedClient);
            Assert.NotNull(resolvedClient);
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
