using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IEmailEntity
    {
        string Name { get; set; }
        string Email { get; set; }
    }
}
