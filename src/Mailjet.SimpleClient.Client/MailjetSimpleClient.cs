using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Responses;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient
{
    public class MailjetSimpleClient : IMailjetSimpleClient
    {
        private HttpClient HttpClient { get; set; }

        public MailjetSimpleClient() : this(null) { }
        public MailjetSimpleClient(HttpClient httpClient)
        {
            UseHttpClient(httpClient ?? new HttpClient());
        }

        public async Task<IResponse> SendRequestAsync(IMailjetRequest request)
        {
            var req = new HttpRequestMessage(request.HttpMethod, request.Uri)
            {
                Content = new StringContent(request.RequestBody.ToString(), Encoding.UTF8, "application/json"),
            };
            req.Headers.Authorization = request.AuthenticationHeaderValue;
            req.Headers.UserAgent.ParseAdd(request.UserAgent);
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
