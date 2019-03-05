using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Responses;
using Mailjet.SimpleClient.Logging;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient
{
    public class MailjetSimpleClient : IMailjetSimpleClient
    {
        private HttpClient HttpClient { get; set; }
        private static readonly ILog Log = LogProvider.For<MailjetSimpleClient>();

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
            Log.Info($"Sending {request.HttpMethod} request to {request.Uri}");
            Log.Debug($"Request body: {Environment.NewLine} {request.RequestBody.ToString()}");
            var res = await HttpClient.SendAsync(req);
            Log.Info($"Request was successful: " +res.IsSuccessStatusCode);
            var content = await res.Content.ReadAsStringAsync();
            Log.Debug("Response body: "+content);
            return new ResponseBase(JToken.Parse(content), (int)res.StatusCode, res.IsSuccessStatusCode);
        }

        public void UseHttpClient(HttpClient httpClient)
        {
            Log.Debug("Custom HttpClient set");
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
    }


}
