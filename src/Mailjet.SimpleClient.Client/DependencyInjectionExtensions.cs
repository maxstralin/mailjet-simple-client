using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Client
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Add default MailjetEmailClient as a service
        /// </summary>
        /// <param name="config">Configuration action</param>
        /// <param name="serviceLifetime">Lifetime of the client, defaults to Transient</param>
        public static void AddMailjetEmailClient(this IServiceCollection serviceDescriptors, Action<IMailjetEmailOptions> config, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            var opts = new MailjetEmailOptions();
            config(opts);
            serviceDescriptors.AddMailjetEmailClient(opts, serviceLifetime);
        }

        /// <summary>
        /// Add default MailjetEmailClient as a service
        /// </summary>
        /// <param name="mailjetEmailOptions">Instance of an IMailjetEmailOptions</param>
        /// <param name="serviceLifetime">Lifetime of the client, defaults to Transient</param>
        public static void AddMailjetEmailClient(this IServiceCollection serviceDescriptors, IMailjetEmailOptions mailjetEmailOptions, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            serviceDescriptors.AddSingleton(mailjetEmailOptions);
            serviceDescriptors.AddMailjetEmailClient<MailjetEmailClient>(serviceLifetime);
        }

        /// <summary>
        /// Add your own implementation of a client
        /// </summary>
        /// <typeparam name="T">An IMailjetEmailClient</typeparam>
        /// <param name="serviceLifetime">Lifetime of your client, defaults to Transient</param>
        /// <remarks>Note that this does not add <c>IMailjetEmailOptions</c> as a service as it makes no assumption on your implementation</remarks>
        public static void AddMailjetEmailClient<T>(this IServiceCollection serviceDescriptors, ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where T : class, IMailjetEmailClient
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(IMailjetEmailClient), typeof(T), serviceLifetime));
        }
    }
}