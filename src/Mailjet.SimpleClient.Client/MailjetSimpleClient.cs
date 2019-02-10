using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Mailjet.SimpleClient.Client
{
    public class MailjetSimpleClient : IVersionedClient, IVersionlessClient
    {
        public virtual ApiVersion ApiVersion { get; protected set; }
        public virtual IMailjetOptions MailjetOptions { get; } = new MailjetOptions();
        
        protected MailjetSimpleClient(ApiVersion apiVersion, Action<IMailjetOptions> options) : this(options)
        {
            ApiVersion = apiVersion;
        }
        protected MailjetSimpleClient(Action<IMailjetOptions> options)
        {
            options(MailjetOptions);
        }
        
        public virtual IVersionedClient SetVersion(ApiVersion apiVersion)
        {
            ApiVersion = apiVersion;
            return this;
        }

        public static IVersionedClient Create(ApiVersion apiVersion, Action<IMailjetOptions> options, ) => new MailjetSimpleClient(apiVersion, options);
        public static IVersionlessClient Create(Action<IMailjetOptions> options) => new MailjetSimpleClient(options);
    }


}
