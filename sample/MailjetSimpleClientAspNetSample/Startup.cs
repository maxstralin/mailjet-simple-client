using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.SimpleClient;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Core.Models.Sms;
using Mailjet.SimpleClient.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MailjetSimpleClientAspNetSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMailjetClients(opt =>
            {
                //Set up settings
                opt.EmailOptions.SandboxMode = true;
                opt.SmsOptions.SmsApiVersion = SmsApiVersion.V4;
                opt.PrivateKey = Environment.GetEnvironmentVariable("MAILJET_PRIVATE_KEY");
                opt.PublicKey = Environment.GetEnvironmentVariable("MAILJET_PUBLIC_KEY");
                opt.Token = Environment.GetEnvironmentVariable("MAILJET_TOKEN");
            });
        }

        //Let's call it as a dependency here, for the sake of showing that the DI is working, but not very clever to do async here
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMailjetEmailClient mailjetEmailClient, IMailjetSimpleClient mailjetSimpleClient, IMailjetOptions mailjetOptions, IMailjetSmsClient mailjetSmsClient)
        {
            var email = new EmailMessage("Test Testsson", "test@test.com");
            //var emailResponse = mailjetEmailClient.SendAsync(email).GetAwaiter().GetResult();

            var sms = new SmsMessage
            {
                To = Environment.GetEnvironmentVariable("MAILJET_TEST_PHONE"),
                From = "Max Test",
                Text = "You should receive this :)"
            };
            var smsResponse = mailjetSmsClient.SendAsync(sms).GetAwaiter().GetResult();

            //The low level MailjetSimpleClient takes an IRequestFactory for sending a request. Anything that implements this (properly) can send whatever type of request
            //This is essentially the equivalent of what is being done in SendAsync() above.
            var basicResponse = mailjetSimpleClient.SendRequestAsync(new SendEmailRequest(email, mailjetOptions)).GetAwaiter().GetResult();
            var basicResponse2 = mailjetSimpleClient.SendRequestAsync(new SendSmsRequest(sms, mailjetOptions));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
