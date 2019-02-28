using Newtonsoft.Json;
using System;

namespace Mailjet.SimpleClient.Entities
{
    public class InterfaceJsonConverter<TConcrete> : JsonConverter where TConcrete : class
    {
        public override bool CanConvert(Type objectType) => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TConcrete>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
