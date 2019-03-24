using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IGetMessageHistoryResponse : IResponse<IRetrieveDetailsResponse<IEnumerable<IMessageHistory>>>
    {
    }
}
