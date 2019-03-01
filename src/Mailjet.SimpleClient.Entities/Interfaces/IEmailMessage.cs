namespace Mailjet.SimpleClient.Core.Interfaces
{
    /// <summary>
    /// An email message
    /// </summary>
    public interface IEmailMessage : IEmailEntities
    {
        /// <summary>
        /// Subject of the email
        /// </summary>
        string Subject { get; set; }
    }
}
