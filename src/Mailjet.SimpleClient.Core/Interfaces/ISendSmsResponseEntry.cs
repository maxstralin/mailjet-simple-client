namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendSmsResponseEntry
    {
        string From { get; set; }
        string To { get; set; }
        string Text { get; set; }
        int MessageId { get; set; }
        int SmsCount { get; set; }
        long CreationTimestamp { get; set; }
        long SentTimestamp { get; set; }
    }
}