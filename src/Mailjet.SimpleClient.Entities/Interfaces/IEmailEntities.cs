using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// All recipient types and sender
    /// </summary>
    public interface IEmailEntities
    {
        /// <summary>
        /// Who is sending the email
        /// </summary>
        IEmailEntity From { get; set; }
        /// <summary>
        /// The main recipients
        /// </summary>
        IEnumerable<IEmailEntity> To { get; set; }
        /// <summary>
        /// Copied in recipients
        /// </summary>
        IEnumerable<IEmailEntity> Cc { get; set; }
        /// <summary>
        /// Hidden recipients
        /// </summary>
        IEnumerable<IEmailEntity> Bcc { get; set; }
    }
}
