using Newtonsoft.Json;
using System.Linq;
using Mailjet.SimpleClient.Core.Models.Requests;
using Mailjet.SimpleClient.Tests.Mocks;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    public class BaseRequestTests
    {
        [Fact]
        public void Test_IgnoreSerialisingNullValues()
        {
            var req = new BaseRequestMock();
            var obj = new { a = (string)null, b = true, c = false };

            req.SetRequestBody(obj);

            Assert.Null(obj.a);
            Assert.Null(req.RequestBody[nameof(obj.a)]);
            Assert.IsNotType<JValue>(req.RequestBody[nameof(obj.a)]);
        }

        [Fact]
        public void Test_ValidateSerialisation()
        {
            var req = new BaseRequestMock();
            var obj = new { a = (string)null, b = true, c = 123, d = "string", e = 123.321 };

            req.SetRequestBody(obj);

            Assert.Null(req.RequestBody[nameof(obj.a)]);            
            Assert.Equal(req.RequestBody.Value<bool>(nameof(obj.b)), obj.b);
            Assert.Equal(req.RequestBody.Value<int>(nameof(obj.c)), obj.c);
            Assert.Equal(req.RequestBody.Value<string>(nameof(obj.d)), obj.d);
            Assert.Equal(req.RequestBody.Value<double>(nameof(obj.e)), obj.e);

        }

        [Fact]
        public void Test_ValidateUserAgent()
        {
            var req = new BaseRequestMock();
            Assert.True(req.UserAgent == "mailjet-simple-client/1.0");
        }

        [Fact]
        public void Test_ValidateUri()
        {
            var req = new BaseRequestMock();
            Assert.Equal($@"{req.BaseUri}/{req.Path}", req.Uri);
        }

    }

}
