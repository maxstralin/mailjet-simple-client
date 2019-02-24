using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Resolvers
{
    public class V3ContractResolver : DefaultContractResolver
    {
        //TODO: Add property translations
        public readonly Dictionary<string, string> PropertyMappings = new Dictionary<string, string>()
        {
            [nameof(IEmailMessage.HtmlBody)] = "Html-Part",
            [nameof(IEmailMessage.PlainTextBody)] = "Plain-Part",
            [nameof(IEmailMessage.UseTemplateLanguage)] = "Mj-TemplateLanguage",
            [nameof(IEmailMessage.Variables)] = "Vars"
        };
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);
            if (PropertyMappings.ContainsKey(member.Name)) prop.PropertyName = PropertyMappings[member.Name];

            return prop;
        }

    }
}
