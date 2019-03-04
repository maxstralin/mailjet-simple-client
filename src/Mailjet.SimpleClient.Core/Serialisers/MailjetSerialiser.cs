using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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

    public static class LogSerialiser
    {
        public static string Serialise(object obj)
        {
            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter()
                }
            };
            return JsonConvert.SerializeObject(obj, Formatting.Indented, settings);
        }
    }

}
