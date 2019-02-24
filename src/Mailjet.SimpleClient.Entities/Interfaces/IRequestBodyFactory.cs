using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Interfaces
{
    public interface IRequestBodyFactory
    {
        JToken CreateRequestBody();
    }
}
