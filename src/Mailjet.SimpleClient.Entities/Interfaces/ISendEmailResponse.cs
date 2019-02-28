using Mailjet.SimpleClient.Entities.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface ISendEmailResponse : IResponse<IEnumerable<ISendEmailResponseEntry>>
    {
    }
}
