using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IEmailMessage : IEmailEntities
    {
        string Subject { get; set; }
        string HtmlBody { get; set; }
        string PlainTextBody { get; set; }
        bool UseTemplateLanguage { get; set; }
    }
}
