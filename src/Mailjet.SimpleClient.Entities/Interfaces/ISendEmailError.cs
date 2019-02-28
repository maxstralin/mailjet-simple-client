using System.Collections.Generic;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface ISendEmailError
    {
        string ErrorCode { get; set; }
        string ErrorIdentifier { get; set; }
        string ErrorMessage { get; set; }
        IEnumerable<string> ErrorRelatedTo { get; set; }
        int StatusCode { get; set; }
    }
}