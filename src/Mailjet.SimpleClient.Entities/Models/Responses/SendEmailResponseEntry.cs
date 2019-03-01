using System.Collections.Generic;
using System.Linq;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Errors;

namespace Mailjet.SimpleClient.Core.Models.Responses
{
    public class SendEmailResponseEntry : ISendEmailResponseEntry
    {
        public bool Successful => Status == "success";
        public string Status { get; set; }
        public IEnumerable<ISendEmailResponseResult> To { get; set; } = Enumerable.Empty<SendEmailResponseResult>();
        public IEnumerable<ISendEmailResponseResult> Cc { get; set; } = Enumerable.Empty<SendEmailResponseResult>();
        public IEnumerable<ISendEmailResponseResult> Bcc { get; set; } = Enumerable.Empty<SendEmailResponseResult>();
        public IEnumerable<ISendEmailError> Errors { get; set; } = Enumerable.Empty<SendEmailError>();
    }
}
