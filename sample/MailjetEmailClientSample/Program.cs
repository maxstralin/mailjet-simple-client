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
            var message = new EmailMessage(new EmailEntity("Max Strålin", "cool-cat@devmasters.se"))
            {
                To = new List<EmailEntity> { new EmailEntity("Max Strålin", "max.stralin@devmasters.se") },
                HtmlBody = @"<div>Fantastic sample email. Need a job?</div>"
            };
            var res = await client.SendAsync(message);
        }
    }
}
