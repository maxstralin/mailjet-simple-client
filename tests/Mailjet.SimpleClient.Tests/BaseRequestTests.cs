using Newtonsoft.Json;
using System.Linq;
using Mailjet.SimpleClient.Core.Models.Requests;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    class BaseRequestTestClass : BaseRequest
    {
        public BaseRequestTestClass()
        {
            HttpMethod = new System.Net.Http.HttpMethod("GET");
            Path = "test-1";
        }
        public new void SetRequestBody(object obj, JsonSerializer jsonSerializer = null) => base.SetRequestBody(obj, jsonSerializer);
    }

    public class BaseRequestTests
    {
        [Fact]
        public void Test_IgnoreSerialisingNullValues()
        {
            var req = new BaseRequestTestClass();
            var obj = new { a = (string)null, b = true, c = false };

            req.SetRequestBody(obj);

            Assert.Null(obj.a);
            Assert.Null(req.RequestBody[nameof(obj.a)]);
        }

        [Fact]
        public void Test_ValidateSerialisation()
        {
            var req = new BaseRequestTestClass();
            var obj = new { a = (string)null, b = true, c = false };

            req.SetRequestBody(obj);

            Assert.Equal(req.RequestBody.Value<bool>(nameof(obj.b)), obj.b);
            Assert.Equal(req.RequestBody.Value<bool>(nameof(obj.c)), obj.c);
        }

        [Fact]
        public void Test_ValidateUserAgent()
        {
            var req = new BaseRequestTestClass();
            req.SetRequestBody(new { });

            var message = req.CreateRequest();

            Assert.True(message.Headers.UserAgent.Single().Product.ToString() == req.UserAgent);
        }

        [Fact]
        public void Test_ValidateUrl()
        {
            var req = new BaseRequestTestClass();

            req.SetRequestBody(new { });



            Assert.Equal($@"{req.BaseUrl}/{req.Path}", req.FullUrl);
        }

    }

}
