using Mailjet.SimpleClient.Entities.Models.Errors;
using Mailjet.SimpleClient.Entities.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface ISendEmailResponseEntry
    {
        IEnumerable<ISendEmailResponseResult> To { get; set; }
        IEnumerable<ISendEmailResponseResult> Bcc { get; set; }
        IEnumerable<ISendEmailResponseResult> Cc { get; set; }
        IEnumerable<ISendEmailError> Errors { get; set; }
        string Status { get; set; }
        bool Successful { get; }
        
    }
}
