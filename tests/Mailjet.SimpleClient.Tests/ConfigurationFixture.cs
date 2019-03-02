using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Options;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Tests
{
    public class ConfigurationFixture
    {

        public readonly IMailjetEmailOptions MailjetEmailOptions;
        public const int TestTemplateId = 711944;
        public ConfigurationFixture()
        {
            LoadEnvironmentVarsFromFile();
            MailjetEmailOptions = new MailjetEmailOptions
            {
                ApiVersion = EmailApiVersion.V3_1,
                SandboxMode = true,
                PrivateKey = Environment.GetEnvironmentVariable("MAILJET_PRIVATE_KEY"),
                PublicKey = Environment.GetEnvironmentVariable("MAILJET_PUBLIC_KEY")
            };
        }

        void LoadEnvironmentVarsFromFile()
        {
            var path = Environment.CurrentDirectory + @"\Properties\environment_vars.json";
            if (!File.Exists(path)) return;

            var text = File.ReadAllText(path);
            var json = JObject.Parse(text);

            if (!json.HasValues) return;

            foreach (var environmentVar in json)
            {
                Environment.SetEnvironmentVariable(environmentVar.Key, environmentVar.Value.Value<string>());
            }
        }

    }
}
