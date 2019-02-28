using Mailjet.SimpleClient.Entities.Interfaces;
using Mailjet.SimpleClient.Entities.Models.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mailjet.SimpleClient.Client
{
    public class MailjetSimpleClient : IMailjetSimpleClient
    {
        private HttpClient HttpClient { get; set; }

        public MailjetSimpleClient() : this(null) { }
        public MailjetSimpleClient(HttpClient httpClient)
        {
            UseHttpClient(httpClient ?? new HttpClient());
        }

        public async Task<IResponse> SendRequestAsync(IRequestFactory request)
        {
            var req = request.CreateRequest();
            var res = await HttpClient.SendAsync(req);

            var content = await res.Content.ReadAsStringAsync();

            return new Response(JToken.Parse(content), (int)res.StatusCode, res.IsSuccessStatusCode);
        }

        public void UseHttpClient(HttpClient httpClient)
        {

            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
    }


}
