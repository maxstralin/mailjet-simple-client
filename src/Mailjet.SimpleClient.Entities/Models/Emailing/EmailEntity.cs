using Mailjet.SimpleClient.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Emailing
{
    public class EmailEntity : IEmailEntity
    {
        public EmailEntity(string name, string email)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
