using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Core.Interfaces
{
    public interface IQueryFilter
    {
        IEnumerable<KeyValuePair<string, string>> CreateQueryParams();
        string CreateQueryParamsString();
    }
}
