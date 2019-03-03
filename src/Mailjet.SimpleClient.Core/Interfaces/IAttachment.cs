namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IAttachment
    {
        /// <summary>
        /// E.g. image/jpeg
        /// </summary>
        string ContentType { get; set; }
        /// <summary>
        /// E.g. picture.jpg
        /// </summary>
        string Filename { get; set; }
        /// <summary>
        /// Base64 encoded string of the file's contents
        /// </summary>
        string Base64Content { get; set; }
    }
}