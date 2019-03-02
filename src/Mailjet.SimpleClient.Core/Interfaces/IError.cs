using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IError
    {
        int StatusCode { get; set; }
        string ErrorIdentifier { get; set; }
        string ErrorMessage { get; set; }
    }
}
