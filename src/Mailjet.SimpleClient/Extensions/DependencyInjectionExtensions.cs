using System;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using Mailjet.SimpleClient.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Mailjet.SimpleClient.Extensions
{
    public static class DependencyInjectionExtensions
    {
        private static readonly ILog Log = LogProvider.GetCurrentClassLogger();
        /// <summary>
        /// Registers <c>IMailjetOptions</c>, <c>IMailjetEmailClient</c>, <c>IMailjetSimpleClient</c>
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="config">Configuration action</param>
        public static void AddMailjetClients(this IServiceCollection serviceCollection, Action<IMailjetOptions> config)
        {
            Log.Debug("Adding Mailjet clients to dependency injection");
            var options = new MailjetOptions();
            config(options);
            serviceCollection.AddMailjetOptions(options);
            serviceCollection.AddMailjetSimpleClient();
            serviceCollection.AddMailjetEmailClient();
            serviceCollection.AddMailjetSmsClient();
            Log.Debug("Added Mailjet clients to dependency injection");
        }

        /// <summary>
        /// Adds an <c>IMailjetOptions</c> instance as a singleton
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="options">Mailjet options</param>
        public static void AddMailjetOptions(this IServiceCollection serviceCollection, IMailjetOptions options)
        {
            serviceCollection.AddSingleton(options);
        }

        /// <summary>
        /// Add default MailjetEmailClient as a service
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceLifetime">Lifetime of the client, defaults to Transient</param>
        private static void AddMailjetEmailClient(this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            serviceCollection.AddMailjetEmailClient<MailjetEmailClient>(serviceLifetime);
        }
        /// <summary>
        /// Add your own implementation of a client. Note that this does not add <c>IMailjetEmailOptions</c> as a service as it makes no assumption on your implementation
        /// </summary>
        /// <typeparam name="T">An IMailjetEmailClient</typeparam>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceLifetime">Lifetime of your client, defaults to Transient</param>
        public static void AddMailjetEmailClient<T>(this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where T : class, IMailjetEmailClient
        {
            serviceCollection.Add(new ServiceDescriptor(typeof(IMailjetEmailClient), typeof(T), serviceLifetime));
        }

        private static void AddMailjetSmsClient(this IServiceCollection serviceCollection,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            serviceCollection.AddMailjetSmsClient<MailjetSmsClient>(serviceLifetime);
        }

        public static void AddMailjetSmsClient<T>(this IServiceCollection serviceCollection,
            ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where T : class, IMailjetSmsClient
        {
            serviceCollection.Add(new ServiceDescriptor(typeof(IMailjetSmsClient), typeof(T), serviceLifetime));

        }

        /// <summary>
        /// Add default MailjetSimpleClient as a service
        /// </summary>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceLifetime">Lifetime of the client, defaults to Transient</param>
        private static void AddMailjetSimpleClient(this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            serviceCollection.AddMailjetSimpleClient<MailjetSimpleClient>(serviceLifetime);
        }

        /// <summary>
        /// Add your own implementation of a client. Note that this does not add <c>IMailjetEmailOptions</c> as a service as it makes no assumption on your implementation
        /// </summary>
        /// <typeparam name="T">An IMailjetEmailClient</typeparam>
        /// <param name="serviceCollection">Service collection</param>
        /// <param name="serviceLifetime">Lifetime of your client, defaults to Transient</param>
        public static void AddMailjetSimpleClient<T>(this IServiceCollection serviceCollection, ServiceLifetime serviceLifetime = ServiceLifetime.Transient) where T : class, IMailjetSimpleClient
        {
            serviceCollection.Add(new ServiceDescriptor(typeof(IMailjetSimpleClient), typeof(T), serviceLifetime));
        }
    }
}