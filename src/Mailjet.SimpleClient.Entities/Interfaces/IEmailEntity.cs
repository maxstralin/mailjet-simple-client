namespace Mailjet.SimpleClient.Entities.Interfaces
{
    /// <summary>
    /// An IEmailEntity may be a recipient or a sender
    /// </summary>
    /// <remarks>I.e. anything that has a name and an email</remarks>
    public interface IEmailEntity
    {
        /// <summary>
        /// Name of the email entity
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Email of the recipient
        /// </summary>
        string Email { get; set; }
    }
}
