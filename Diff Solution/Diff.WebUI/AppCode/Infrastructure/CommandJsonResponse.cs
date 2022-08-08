namespace Diff.WebUI.AppCode.Infrastructure
{
    public class CommandJsonResponse
    {
        public string Message { get; set; }
        public bool Error { get; set; }
        public CommandJsonResponse()
        {

        }

        public CommandJsonResponse(bool error, string message)
        {
            this.Error = error;
            this.Message = message;
        }
    }
}
