using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IEmailEntities
    {
        IEmailEntity From { get; set; }
        IEnumerable<IEmailEntity> To { get; set; }
        IEnumerable<IEmailEntity> Cc { get; set; }
        IEnumerable<IEmailEntity> Bcc { get; set; }
    }
}
