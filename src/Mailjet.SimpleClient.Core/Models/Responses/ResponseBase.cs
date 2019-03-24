using Mailjet.SimpleClient.Core.Interfaces;
using Mailjet.SimpleClient.Core.Models.Errors;
using Newtonsoft.Json.Linq;

namespace Mailjet.SimpleClient.Core.Models.Responses
{
    public class ResponseBase : IResponse
    {
        public ResponseBase(string rawResponse, int statusCode, bool successful)
        {
            RawResponse = rawResponse;
            StatusCode = statusCode;
            Successful = successful;

            try
            {
                ParsedResponse = JToken.Parse(rawResponse);

                //Seems to be an error response, populate the Error property
                if (ParsedResponse[nameof(Error.ErrorIdentifier)] != null)
                {
                    Error = ParsedResponse.ToObject<Error>();
                }

            }
            catch
            {

            }

        }
        public string RawResponse { get; protected set; }
        public JToken ParsedResponse { get; }
        public IError Error { get; protected set; }

        public int StatusCode { get; protected set; }

        public bool Successful { get; protected set; }
    }

    public class ResponseBase<T> : ResponseBase, IResponse<T> where T : class
    {
        public ResponseBase(T data, string rawResponse, int statusCode, bool successful) : base(rawResponse, statusCode, successful)
        {
            Data = data;
        }

        public T Data { get; }

    }

}
