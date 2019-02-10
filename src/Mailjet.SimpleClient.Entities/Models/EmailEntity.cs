using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models
{
    public class EmailEntity : IEmailEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
