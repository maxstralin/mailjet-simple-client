using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// An email message
    /// </summary>
    public interface IEmailMessage : IEmailEntities
    {
        /// <summary>
        /// Subject of the email
        /// </summary>
        string Subject { get; set; }
    }
}
