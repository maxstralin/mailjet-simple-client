using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Emailing;
using Mailjet.SimpleClient.Entities.Models.Errors;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Entities.Models.Responses
{
    public class SendEmailResponseEntry
    {
        public bool Successful { get => Status == "success"; }
        public string Status { get; set; }
        public IEnumerable<SendEmailResponseResult> To { get; set; } = Enumerable.Empty<SendEmailResponseResult>();
        public IEnumerable<SendEmailResponseResult> Cc { get; set; } = Enumerable.Empty<SendEmailResponseResult>();
        public IEnumerable<SendEmailResponseResult> Bcc { get; set; } = Enumerable.Empty<SendEmailResponseResult>();

        public IEnumerable<SendEmailError> Errors { get; set; } = Enumerable.Empty<SendEmailError>();

        /// <summary>
        /// Concats To, Cc, and Bcc, to avoid having to access each property
        /// </summary>
        /// <returns>Concatenated IEnumerable of To, Cc, Bcc</returns>
        public IEnumerable<SendEmailResponseResult> GetResultsForAllRecipients()
        {
            return To.Concat(Cc).Concat(Bcc);
        }

    }
}
