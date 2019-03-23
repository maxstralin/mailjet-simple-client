using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Requests
{
    public class GetEmailRequest : RequestBase
    {
        public GetEmailRequest(IMailjetKeys options, long messageId)
        {
            AuthenticationHeaderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{options.PublicKey}:{options.PrivateKey}")));
            HttpMethod = new HttpMethod("GET");
            Path = "v3/REST/message/" + messageId;
        }
    }
}
