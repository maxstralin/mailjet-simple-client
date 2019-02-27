using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Responses
{
    public class SendEmailResponse
    {
        public IEnumerable<SendEmailResponseEntry> Messages { get; set; }
    }
}
