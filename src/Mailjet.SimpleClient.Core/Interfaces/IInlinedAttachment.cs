using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IInlinedAttachment : IAttachment
    {
        string ContentId { get; set; }
    }
}
