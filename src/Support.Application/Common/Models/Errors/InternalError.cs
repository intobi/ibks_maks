namespace Support.Application.Errors
{
    public enum ErrorReason
    {
        NotFound,
        ValidationFailed,
        NotTicketsFoundError
    }

    public abstract record InternalError(ErrorReason Reason, string Message);

    public record NotFoundError(object Id) : InternalError(ErrorReason.NotFound, $"Entity with ID {Id} not found.");

    public record NotTicketsFoundError(IEnumerable<string> Errors) : InternalError(ErrorReason.NotTicketsFoundError, $"Tickets errors occured.")
    {
        public IEnumerable<string> Errors { get; init; } = Errors;
    }


    public record ValidationError(IEnumerable<string> Errors) : InternalError(ErrorReason.ValidationFailed, "Validation errors occurred.")
    {
        public IEnumerable<string> Errors { get; init; } = Errors;
    }
}
