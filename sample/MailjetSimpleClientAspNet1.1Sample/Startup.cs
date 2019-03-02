using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.SimpleClient;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MailjetSimpleClientAspNet1_1Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Register default email client with action configuration
            services.AddMailjetEmailClient((opt) =>
            {
                opt.SandboxMode = true;
                opt.PrivateKey = "";
                opt.PublicKey = "";
            });

            //Equally valid, if you want to pass an options instance instead of configuring through action
            //services.AddMailjetEmailClient(new MailjetEmailOptions
            //{
            //    SandboxMode = true
            //});

            //Add your own implementation of IMailjetEmailClient.
            //Note that the other DI extensions add IMailjetEmailOptions as a singleton,
            //whereas this makes no assumption of your implementation of IMailjetEmailClient so no options are added to the DI container
            //services.AddMailjetEmailClient<MailjetEmailClient>();

            services.AddMailjetSimpleClient();

        }

        //Let's call it as a dependency here, for the sake of showing that the DI is working, but not very clever to do async here
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMailjetEmailClient mailjetEmailClient, IMailjetSimpleClient mailjetSimpleClient)
        {
            var email = new EmailMessage("Test Testsson", "test@test.com");
            var res = mailjetEmailClient.SendAsync(email).GetAwaiter().GetResult();

            //The low level MailjetSimpleClient takes an IRequestFactory for sending a request. Anything that implements this (properly) can send whatever type of request
            //This is essentially the equivalent of what is being done in SendAsync() above.
            var res2 = mailjetSimpleClient.SendRequestAsync(new SendEmailRequest(email,
                (mailjetEmailClient as MailjetEmailClient).Options)).GetAwaiter().GetResult();

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
