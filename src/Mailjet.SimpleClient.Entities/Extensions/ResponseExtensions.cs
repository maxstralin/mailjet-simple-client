using System.Collections.Generic;
using System.Linq;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Extensions
{
    public static class ResponseExtensions
    {
        /// <summary>
        /// Concats To, Cc, and Bcc, to avoid having to access each property
        /// </summary>
        /// <returns>Concatenated IEnumerable of To, Cc, Bcc</returns>
        public static IEnumerable<ISendEmailResponseResult> GetEntriesForAllRecipients(this ISendEmailResponseEntry entry) {
            return entry.To.Concat(entry.Cc).Concat(entry.Bcc);
        }
    }
}
