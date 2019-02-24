using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Client
{
    class TestJsonConverter : JsonConverter<IEmailEntity>
    {
        public override void WriteJson(JsonWriter writer, IEmailEntity value, JsonSerializer serializer)
        {
            var jObject = new JObject
            {
                ["SenderName"] = value?.Name,
                ["SenderEmail"] = value?.Email
            };

            jObject.WriteTo(writer);
        }

        public override IEmailEntity ReadJson(JsonReader reader, Type objectType, IEmailEntity existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
