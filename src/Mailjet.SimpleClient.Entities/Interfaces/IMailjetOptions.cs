using Mailjet.SimpleClient.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IMailjetOptions : IMailjetSmsOptions, IMailjetEmailOptions
    {
        new ApiVersion ApiVersion { get; set; }
    }
}
