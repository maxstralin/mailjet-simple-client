namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendSmsCost
    {
        double Value { get; set; }
        string Currency { get; set; }
    }
}