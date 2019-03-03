using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    /// <inheritdoc />
    public class Attachment : IAttachment
    {
        /// <inheritdoc />
        public string ContentType { get; set; }

        /// <inheritdoc />
        public string Filename { get; set; }

        /// <inheritdoc />
        public string Base64Content { get; set; }
    }
}
