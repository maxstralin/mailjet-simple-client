using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Newtonsoft.Json;

namespace Mailjet.SimpleClient.Core.Models.Emailing
{
    public class InlinedAttachment : Attachment, IInlinedAttachment
    {
        /// <summary>
        /// The ID to use for inline use, e.g. &lt;img src="cid:MyId"/&gt;
        /// </summary>
        [JsonProperty(PropertyName = "ContentID")]
        public string ContentId { get; set; }
    }
}
