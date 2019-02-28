using Mailjet.SimpleClient.Client;
using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Options;
using Mailjet.SimpleClient.Entities.Models.Requests;
using Mailjet.SimpleClient.Tests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class MailjetEmailClientTest
    {
        //TODO: Should probably be moved into a TestFixture or something since now it's a bit wet... (not DRY)
        private readonly IMailjetEmailOptions options = new MailjetEmailOptions
        {
            ApiVersion = EmailApiVersion.V3_1,
            PrivateKey = "Max",
            PublicKey = "Strålin"
        };

        [Fact]
        public void Test_ValidateOptionsInstance()
        {
            var client = new MailjetEmailClient(options);
            
            
            Assert.Same(options, client.Options);
            Assert.Equal(options, client.Options);
        }

        [Fact]
        public void Test_ValidateOptionsProperties()
        {
            var client = new MailjetEmailClient((opt) =>
            {
                opt.PrivateKey = options.PrivateKey;
                opt.PublicKey = options.PublicKey;
                opt.SandboxMode = options.SandboxMode;
                opt.ApiVersion = options.ApiVersion;
            });

            Assert.NotSame(options, client.Options);
            Assert.Equal(options, client.Options);
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
            options.ApiVersion = EmailApiVersion.V3;
            Assert.Throws<UnsupportedApiVersionException>(() => new MailjetEmailClient(options));
        }

        [Fact]
        public void Test_ValidateDefaultDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddMailjetEmailClient(options);

            var serviceProvider = services.BuildServiceProvider();
            var resolvedOptions = serviceProvider.GetRequiredService<IMailjetEmailOptions>();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetEmailClient>();

            Assert.Equal(resolvedOptions, options);
            Assert.IsAssignableFrom<IMailjetEmailClient>(resolvedClient);
            Assert.IsType<MailjetEmailClient>(resolvedClient);
            Assert.NotNull(resolvedClient);
        }

        [Fact]
        public void Test_ValidateOptionsByActionDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddMailjetEmailClient((opt) => opt.PrivateKey = options.PrivateKey);

            var serviceProvider = services.BuildServiceProvider();
            var resolvedOptions = serviceProvider.GetRequiredService<IMailjetEmailOptions>();
            var resolvedClient = serviceProvider.GetRequiredService<IMailjetEmailClient>();

            Assert.Equal(resolvedOptions.PrivateKey, options.PrivateKey);
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

    }
}
