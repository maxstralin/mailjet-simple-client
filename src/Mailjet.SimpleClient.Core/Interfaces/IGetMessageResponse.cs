using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Models.Responses.Emailing;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IGetMessageResponse : IResponse<IRetrieveDetailsResponse<IMessageDetails>>
    {
    }
}
