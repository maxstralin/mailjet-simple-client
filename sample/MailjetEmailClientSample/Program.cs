using Mailjet.SimpleClient.Client;
using Mailjet.SimpleClient.Entities.Models.Emailing;
using Mailjet.SimpleClient.Entities.Models.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailjetEmailClientSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new MailjetEmailClient(new MailjetEmailOptions
            {
                PrivateKey = Environment.GetEnvironmentVariable("MAILJET_PRIVATE_KEY"),
                PublicKey = Environment.GetEnvironmentVariable("MAILJET_PUBLIC_KEY"),
                SandboxMode = true
            });
            var message = new EmailMessage(new EmailEntity("Max Strålin", "max.stralin@devmasters.se"))
            {
                To = new List<EmailEntity> { new EmailEntity("Max Strålin", "max.stralin@devmasters.se") },
                HtmlBody = @"<div>Fantastic sample email. Need a job?</div>"
            };
            //A successful message in sandbox mode
            var successful = await client.SendAsync(message);
            //Let's empty the recipients list, making the request invalid
            message.To = new List<EmailEntity> {  };
            //Will indicate an error
            var error = await client.SendAsync(message);
        }
    }
}
