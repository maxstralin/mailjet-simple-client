using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// A templated message with an integer TemplateId
    /// </summary>
    public interface ITemplateEmailMessage : ITemplateEmailMessage<int>
    {
    }
    /// <summary>
    /// Template message with generic templateId
    /// </summary>
    /// <typeparam name="T">The type of the TemplateId</typeparam>
    public interface ITemplateEmailMessage<T> : IEmailEntities
    {
        /// <summary>
        /// The ID of the template 
        /// </summary>
        T TemplateId { get; }
    }
}