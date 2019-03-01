using System.Collections.Generic;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface ISendEmailResponse : IResponse<IEnumerable<ISendEmailResponseEntry>>
    {
    }
}
