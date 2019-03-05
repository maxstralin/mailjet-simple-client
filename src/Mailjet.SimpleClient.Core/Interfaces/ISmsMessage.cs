namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISmsMessage
    {
        /// <summary>
        /// Customizable sender name. Should be between 3 and 11 characters in length, only alphanumeric characters are allowed.
        /// </summary>
        string From { get; set; }
        /// <summary>
        /// Message recipient. Should be between 3 and 15 characters in length. The number always starts with a plus sign followed by a country code, followed by the number. Phone numbers are expected to comply with the E.164 format.
        /// </summary>
        string To { get; set; }
        /// <summary>
        /// The text part of the message.
        /// </summary>
        string Text { get; set; }
    }
}