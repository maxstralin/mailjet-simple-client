﻿using Mailjet.SimpleClient.Entities.Exceptions;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Requests;
using Mailjet.SimpleClient.Entities.Resolvers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Client
{
    public class MailjetEmailClient : MailjetSimpleClient, IVersionedClient
    {
        public MailjetEmailClient(IMailjetEmailOptions options) : base(new MailjetOptions
        {
            ApiVersion = (ApiVersion)options.ApiVersion,
            PrivateKey = options.PrivateKey,
            PublicKey = options.PublicKey
        })
        {
            //TODO: Implement EmailApiVersion.V3
            if (ApiVersion != EmailApiVersion.V3_1) throw new UnsupportedApiVersionException();
        }

        public new EmailApiVersion ApiVersion { get => (EmailApiVersion)base.ApiVersion; }

        public IMailjetEmailOptions MailjetEmailOptions { get => MailjetOptions; }

        ApiVersion IVersionedClient.ApiVersion => (ApiVersion)ApiVersion;

        Task<HttpResponseMessage> IMailjetSimpleClient.SendRequestAsync(IRequestFactory request)
        {
            throw new NotImplementedException();
        }

        public void Send(IEnumerable<IEmailMessage> emailMessages)
        {

        }

        public void SendAsync(IEmailMessage emailMessage)
        {
            //3.1 wants an array of email messages
        }

        //public void Send(ITemplateEmailMessage templateEmailMessage)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Send(IEnumerable<ITemplateEmailMessage> templateEmailMessages)
        //{
        //    throw new NotImplementedException();
        //}
    }
}