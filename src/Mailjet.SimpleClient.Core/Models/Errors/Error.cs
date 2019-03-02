using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Errors
{
    public class Error : IError
    {
        /// <summary>
        /// Mailjet's error ID
        /// </summary>
        public string ErrorIdentifier { get; set; }
        /// <summary>
        /// Status code 
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Human-readable error message
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
