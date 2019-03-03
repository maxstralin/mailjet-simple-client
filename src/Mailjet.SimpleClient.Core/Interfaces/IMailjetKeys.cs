using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IMailjetKeys
    {
        string PublicKey { get; set; }
        string PrivateKey { get; set; }
    }
}
