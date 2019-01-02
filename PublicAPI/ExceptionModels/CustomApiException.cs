
namespace PublicAPI.ExceptionModels
{
    public class CustomApiException : System.Exception
    {
        public int StatusCode { get; set; }

        public string Content { get; set; }
    }
}
