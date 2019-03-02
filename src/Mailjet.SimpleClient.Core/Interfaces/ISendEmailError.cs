using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendEmailError : IError
    {
        string ErrorCode { get; set; }
        IEnumerable<string> ErrorRelatedTo { get; set; }
    }
}