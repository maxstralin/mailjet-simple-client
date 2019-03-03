using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Serialisers
{
    public static class MailjetSerialiser
    {
        public static JToken Serialise(object obj, JsonSerializer jsonSerializer = null)
        {
            var serialiser = jsonSerializer ?? new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JToken.FromObject(obj, serialiser);
        }
    }
}
