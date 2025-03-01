namespace Support.Application.Common.Models.Errors
{
    public class ErrorResponse(
        string message,
        int statusCode,
        string? details = null,
        IEnumerable<string>? errors = null)
    {
        public string Message { get; set; } = message;
        public int Status { get; set; } = statusCode;
        public string? Details { get; set; } = details;
        public IEnumerable<string>? Errors { get; set; } = errors;
    }
}
