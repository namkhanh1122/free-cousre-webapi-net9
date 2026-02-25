using Newtonsoft.Json;

namespace freecourse_api.Helper
{
    public class ApiResponse
    {
        public int StatusCode {get;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Request was successful.",
                400 => "Bad request.",
                404 => "Resource not found.",
                500 => "Internal server error.",
                _ => "Unknown error."
            };
        }
    }
}