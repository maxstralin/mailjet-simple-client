using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IRetrieveDetailsResponse<T>
    {
        int Count { get; set; }
        int Total { get; set; }
        IEnumerable<T> Data { get; set; }
    }
}