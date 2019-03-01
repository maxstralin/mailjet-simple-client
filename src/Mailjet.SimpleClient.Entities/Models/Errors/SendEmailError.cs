using System.Collections.Generic;
using System.Linq;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Errors
{
    public class SendEmailError : Error, ISendEmailError
    {
        /// <summary>
        /// Error code, e.g. MJ-004
        /// </summary>
        public string ErrorCode { get; set; }
        
        /// <summary>
        /// The properties the error(s) are related to
        /// </summary>
        public IEnumerable<string> ErrorRelatedTo { get; set; } = Enumerable.Empty<string>();
    }
}
