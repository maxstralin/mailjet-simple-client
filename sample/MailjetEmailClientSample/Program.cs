using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mailjet.SimpleClient;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Models.Options;

namespace MailjetEmailClientSample
{
    class Program
    {
        private static async Task Main()
        {
            //Can also be through a configuration action, e.g. (opt) => { PrivateKey = "" }
            var client = new MailjetEmailClient(new MailjetSimpleClient(),  new MailjetOptions
            {
                PrivateKey = Environment.GetEnvironmentVariable("MAILJET_PRIVATE_KEY"),
                PublicKey = Environment.GetEnvironmentVariable("MAILJET_PUBLIC_KEY"),
                EmailOptions = { SandboxMode = true }
            });
            var message = new EmailMessage("Max Strålin", "max.stralin@devmasters.se")
            {
                To = new List<EmailEntity> { new EmailEntity("Max Strålin", "max.stralin@devmasters.se") },
                HtmlBody = @"<div>Fantastic sample email. Need a job?</div>"
            };
            //A successful message in sandbox mode
            var successful = await client.SendAsync(message);
            if (!successful.Successful) throw new Exception("This request should be successful");

            //Send a template email
            var templateMessage = new TemplateEmailMessage(templateId: 711944, from: message.From)
            {
                To = message.To
            };
            var successfulTemplate = await client.SendAsync(templateMessage);
            if (!successfulTemplate.Successful) throw new Exception("This request should be successful");

            //Let's empty the recipients list, making the request invalid
            // ReSharper disable once RedundantEmptyObjectOrCollectionInitializer
            message.To = new List<EmailEntity> {  };
            //Will indicate an error
            var error = await client.SendAsync(message);
            if (error.Successful) throw new Exception("This request should be unsuccessful");
        }
    }
}
