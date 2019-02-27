using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models;
using Mailjet.SimpleClient.Entities.Models.Options;
using Mailjet.SimpleClient.Entities.Models.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Client
{
    public class MailjetSimpleClient : IMailjetSimpleClient
    {
        private readonly HttpClient httpClient;

        public ApiVersion ApiVersion { get => MailjetOptions.ApiVersion; set => MailjetOptions.ApiVersion = value; }
        public IMailjetOptions MailjetOptions { get; protected set; } = null;

        public MailjetSimpleClient(IMailjetOptions options) : this(options, null) { }
        public MailjetSimpleClient(IMailjetOptions options, HttpClient httpClient)
        {
            MailjetOptions = options ?? throw new ArgumentNullException(nameof(options));
            this.httpClient = httpClient ?? new HttpClient();
        }

        public async Task<IResponse> SendRequestAsync(IRequestFactory request)
        {
            var req = request.CreateRequest();
            var res = await httpClient.SendAsync(req);

            var content = await res.Content.ReadAsStringAsync();

            return new Response(JToken.Parse(content), (int)res.StatusCode, res.IsSuccessStatusCode);
        }
    }


}
