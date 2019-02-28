using System.Collections.Generic;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface ISendEmailResponse : IResponse<IEnumerable<ISendEmailResponseEntry>>
    {
    }
}
