using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface ITemplateEmailMessage : IEmailEntities
    {
        int TemplateId { get; set; }
        IDictionary<string, object> Variables { get; set; }
        bool UseTemplateLanguage { get; set; }
    }
}