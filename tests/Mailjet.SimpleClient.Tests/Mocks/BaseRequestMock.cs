using System;
using System.Collections.Generic;
using System.Text;
using Mailjet.SimpleClient.Core.Models.Requests;

namespace Mailjet.SimpleClient.Tests.Mocks
{
    class BaseRequestMock : RequestBase
    {
        public void SetRequestBody(object obj) => base.SetRequestBody(obj);
    }
}
