using Mailjet.SimpleClient.Client;
using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Requests;
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
    }
}
