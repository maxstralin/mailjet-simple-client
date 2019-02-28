using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Errors
{
    public class SendEmailError : ISendEmailError
    {
        /// <summary>
        /// Mailjet's error ID
        /// </summary>
        public string ErrorIdentifier { get; set; }
        /// <summary>
        /// Error code, e.g. MJ-004
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Status code 
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Human-readable error message
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// The properties the error(s) are related to
        /// </summary>
        public IEnumerable<string> ErrorRelatedTo { get; set; } = Enumerable.Empty<string>();
    }
}
