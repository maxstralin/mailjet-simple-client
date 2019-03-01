using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.SimpleClient;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Emailing;
using Mailjet.SimpleClient.Core.Models.Options;
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
            //Register default email client with action configuration
            services.AddMailjetEmailClient((opt) =>
            {
                opt.SandboxMode = true;
                opt.PrivateKey = "";
                opt.PublicKey = "";
            });

            //Equally valid, if you want to pass an options instance instead of configuring through action
            services.AddMailjetEmailClient(new MailjetEmailOptions
            {
                SandboxMode = true
            });

            //Add your own implementation of IMailjetEmailClient.
            //Note that the other DI extensions add IMailjetEmailOptions as a singleton,
            //whereas this makes no assumption of your implementation of IMailjetEmailClient so no options are added to the DI container
            services.AddMailjetEmailClient<MailjetEmailClient>();

        }

        //Let's call it as a dependency here, for the sake of showing that the DI is working, but not very clever to do async here
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMailjetEmailClient mailjetEmailClient)
        {
            var res = mailjetEmailClient.SendAsync(new EmailMessage("Test Testsson", "test@test.com")).GetAwaiter().GetResult();

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
