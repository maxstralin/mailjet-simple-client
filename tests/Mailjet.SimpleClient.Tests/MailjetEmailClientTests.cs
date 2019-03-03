using System.Collections.Generic;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Exceptions;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Models.Options;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class MailjetEmailClientTest : ConfigurationFixture
    {
        [Fact]
        public async Task Test_ValidateSandboxBasicEmailSend()
        {
            MailjetOptions.EmailOptions.SandboxMode = true;
            var client = new MailjetEmailClient(new MailjetSimpleClient(), MailjetOptions);
            var msg = new EmailMessage("Max Strålin", "max.stralin@devmasters.se")
            {
                To = new[] {new EmailEntity("Max Strålin", "max.stralin@devmasters.se"),},
                Subject = "Test of email",
                HtmlBody = "<div>An HTML body</div>"
            };

            var res = await client.SendAsync(msg);

            Assert.True(res.Successful);
        }

        [Fact]
        public async Task Test_ValidateSandboxAttachmentsEmailSend()
        {
            var contentId = "MyImg";
            var contentType = "image/png";
            var base64Content =
                "iVBORw0KGgoAAAANSUhEUgAAAA8AAAAPCAQAAACR313BAAAAE0lEQVR42mNk+M+ABzCOSg8xaQBswQ8Bqy5znAAAAABJRU5ErkJggg==";

            var inlinedAttachment = new InlinedAttachment
            {
                Base64Content = base64Content,
                ContentId = contentId,
                ContentType = contentType,
                Filename = "BlackPixel.png"
            };
            var attachment = new Attachment
            {
                Base64Content = base64Content,
                ContentType = contentType,
                Filename = "BlackPixel_attached.png"
            };

            MailjetOptions.EmailOptions.SandboxMode = true;
            var client = new MailjetEmailClient(new MailjetSimpleClient(), MailjetOptions);
            var msg = new EmailMessage("Max Strålin", "max.stralin@devmasters.se")
            {
                To = new[] { new EmailEntity("Max Strålin", "max.stralin@devmasters.se"), },
                Subject = "Test of email",
                HtmlBody = "<div>An HTML body <img src='cid:MyImg' /></div>",
                InlinedAttachments = new List<IInlinedAttachment>()
                {
                    inlinedAttachment
                },
                Attachments = new List<IAttachment>()
                {
                    attachment
                }
            };

            var res = await client.SendAsync(msg);

            Assert.True(res.Successful);
        }

        [Fact]
        public async Task Test_ValidateSandboxTemplateEmailSend()
        {
            MailjetOptions.EmailOptions.SandboxMode = true;
            var client = new MailjetEmailClient(new MailjetSimpleClient(), MailjetOptions);

            var res = await client.SendAsync(new TemplateEmailMessage(TestTemplateId,"Max Strålin", "max.stralin@devmasters.se")
            {
                To = new[] { new EmailEntity("Max Strålin", "max.stralin@devmasters.se"), },
                Subject = "Test of email"
            });

            Assert.True(res.Successful);
        }

        [Fact]
        public void Test_ValidateOptionsInstance()
        {
            var client = new MailjetEmailClient(new MailjetSimpleClient(), MailjetOptions);

            Assert.Same(MailjetOptions, client.Options);
            Assert.Equal(MailjetOptions, client.Options);
        }

        [Fact]
        public void Test_V3_1DefaultInMailjetEmailOptions()
        {
            var apiVersion = EmailApiVersion.V3_1;
            var options = new MailjetEmailOptions();
            Assert.Equal(options.EmailApiVersion, apiVersion);
        }
    }
}
