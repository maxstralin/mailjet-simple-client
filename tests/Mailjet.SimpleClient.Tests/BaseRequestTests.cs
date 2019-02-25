using Mailjet.SimpleClient.Entities.Models.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Mailjet.SimpleClient.Tests
{
    class BaseRequestTestClass : BaseRequest
    {
        public BaseRequestTestClass()
        {
            HttpMethod = new System.Net.Http.HttpMethod("GET");
        }
        public new void SetRequestBody(object obj, JsonSerializer jsonSerializer = null) => base.SetRequestBody(obj, jsonSerializer: null);
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
        public void Test_ValidateUserAgent()
        {
            var req = new BaseRequestTestClass();
            req.SetRequestBody(new { });

            var message = req.CreateRequest();

            Assert.True(message.Headers.UserAgent.Single().Product.ToString() == req.UserAgent);
        }
    }

}
