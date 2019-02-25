using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetOptions : IMailjetSmsOptions, IMailjetEmailOptions
    {
        new ApiVersion ApiVersion { get; set; }
        bool SandboxMode { get; set; }
    }
}
