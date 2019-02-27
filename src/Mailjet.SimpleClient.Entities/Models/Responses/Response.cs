using Mailjet.SimpleClient.Entities.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailjet.SimpleClient.Entities.Models.Responses
{
    public class Response : IResponse
    {
        public Response(JToken rawResponse, int statusCode, bool successful)
        {
            RawResponse = rawResponse;
            StatusCode = statusCode;
            Successful = successful;
        }
        public JToken RawResponse { get; protected set; }

        public int StatusCode { get; protected set; }

        public bool Successful { get; protected set; }

        /// <summary>
        /// Performs a JToken.ToObject on the RawResponse
        /// </summary>
        /// <typeparam name="T">Request type</typeparam>
        /// <param name="data">Intance of the response</param>
        /// <returns>A response with the raw response converted</returns>
        public virtual IResponse<T> WithData<T>(T data) where T : class
        {
            return new Response<T>(data, RawResponse, StatusCode, Successful);
        }
        /// <summary>
        /// Performs a JToken.ToObject on the RawResponse
        /// </summary>
        /// <typeparam name="T">Request type</typeparam>
        /// <returns>A response with the raw response converted</returns>
        public virtual IResponse<T> WithData<T>() where T : class
        {
            return new Response<T>(RawResponse.ToObject<T>(), RawResponse, StatusCode, Successful);
        }

    }

    public class Response<T> : Response, IResponse<T> where T : class
    {
        public Response(T data, JToken rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }

        public T Data { get; protected set; }
    }
}
