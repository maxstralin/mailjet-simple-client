using Mailjet.SimpleClient.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IVersionedClient : IMailjetSimpleClient
    {
        ApiVersion ApiVersion { get; }
    }
}
