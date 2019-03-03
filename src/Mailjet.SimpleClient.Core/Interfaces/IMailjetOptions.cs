using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Models.Options;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IMailjetOptions : IMailjetKeys, IMailjetToken
    {
        IMailjetEmailOptions EmailOptions { get; }
        IMailjetSmsOptions SmsOptions { get;  }
    }
}
