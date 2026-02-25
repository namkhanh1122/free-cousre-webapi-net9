namespace freecourse_api.Helper
{
    public class ApiOkResponse : ApiResponse
    {
        public string Result { get; }

        public ApiOkResponse(string result) : base(200, "Request successful.")
        {
            Result = result;
        }
    }
}