using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;

namespace Mailjet.SimpleClient.Core.Models.Responses.Sms
{
    public class SendSmsCost : ISendSmsCost
    {
        public double Value { get; set; }
        public string Currency { get; set; }
    }
}
