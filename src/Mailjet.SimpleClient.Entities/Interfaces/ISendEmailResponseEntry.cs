using System.Collections.Generic;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface ISendEmailResponseEntry
    {
        IEnumerable<ISendEmailResponseResult> To { get; set; }
        IEnumerable<ISendEmailResponseResult> Bcc { get; set; }
        IEnumerable<ISendEmailResponseResult> Cc { get; set; }
        IEnumerable<ISendEmailError> Errors { get; set; }
        bool Successful { get; }
        
    }
}
