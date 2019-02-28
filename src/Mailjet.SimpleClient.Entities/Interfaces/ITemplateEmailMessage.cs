namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <inheritdoc />
    public interface ITemplateEmailMessage : ITemplateEmailMessage<int>
    {
    }
    /// <summary>
    /// Template message with generic templateId
    /// </summary>
    /// <typeparam name="T">The type of the TemplateId</typeparam>
    public interface ITemplateEmailMessage<out T> : IEmailEntities
    {
        /// <summary>
        /// The ID of the template 
        /// </summary>
        T TemplateId { get; }
    }
}