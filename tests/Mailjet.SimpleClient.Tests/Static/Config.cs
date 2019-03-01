﻿using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;

namespace Mailjet.SimpleClient.Tests.Static
{
    public static class Config
    {
        public static readonly IMailjetEmailOptions MailjetEmailOptions = new MailjetEmailOptions
        {
            ApiVersion = EmailApiVersion.V3_1,
            PrivateKey = "Max",
            PublicKey = "Strålin"
        };
    }
}