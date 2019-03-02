using System;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Mailjet.SimpleClient.Extensions
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Add default MailjetEmailClient as a service
        /// </summary>
        /// <param name="serviceDescriptors">Service collection</param>
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
        /// <param name="serviceDescriptors">Service collection</param>
        /// <param name="mailjetEmailOptions">Instance of an IMailjetEmailOptions</param>
        /// <param name="serviceLifetime">Lifetime of the client, defaults to Transient</param>
        public static void AddMailjetEmailClient(this IServiceCollection serviceDescriptors, IMailjetEmailOptions mailjetEmailOptions, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            serviceDescriptors.AddSingleton(mailjetEmailOptions);
            serviceDescriptors.AddMailjetEmailClient<MailjetEmailClient>(serviceLifetime);
        }

        /// <summary>
        /// Add your own implementation of a client. Note that this does not add <c>IMailjetEmailOptions</c> as a service as it makes no assumption on your implementation
        /// </summary>
        /// <typeparam name="T">An IMailjetEmailClient</typeparam>
        /// <param name="serviceDescriptors">Service collection</param>
        /// <param name="serviceLifetime">Lifetime of your client, defaults to Transient</param>
        public static void AddMailjetEmailClient<T>(this IServiceCollection serviceDescriptors, ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where T : class, IMailjetEmailClient
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(IMailjetEmailClient), typeof(T), serviceLifetime));
        }

       /// <summary>
        /// Add default MailjetSimpleClient as a service
        /// </summary>
        /// <param name="serviceDescriptors">Service collection</param>
        /// <param name="serviceLifetime">Lifetime of the client, defaults to Transient</param>
        public static void AddMailjetSimpleClient(this IServiceCollection serviceDescriptors, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            serviceDescriptors.AddMailjetSimpleClient<MailjetSimpleClient>(serviceLifetime);
        }

        /// <summary>
        /// Add your own implementation of a client. Note that this does not add <c>IMailjetEmailOptions</c> as a service as it makes no assumption on your implementation
        /// </summary>
        /// <typeparam name="T">An IMailjetEmailClient</typeparam>
        /// <param name="serviceDescriptors">Service collection</param>
        /// <param name="serviceLifetime">Lifetime of your client, defaults to Transient</param>
        public static void AddMailjetSimpleClient<T>(this IServiceCollection serviceDescriptors, ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where T : class, IMailjetSimpleClient
        {
            serviceDescriptors.Add(new ServiceDescriptor(typeof(IMailjetSimpleClient), typeof(T), serviceLifetime));
        }
    }
}