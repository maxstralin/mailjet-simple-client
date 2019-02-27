using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Emailing
{
    public class SendEmailError
    {
        public string ErrorIdentifier { get; set; }
        public string ErrorCode { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<string> ErrorRelatedTo { get; set; } = Enumerable.Empty<string>();
    }
}
