namespace Support.Application.Errors
{
    public enum ErrorReason
    {
        NotFound,
        ValidationFailed,
        WrongAssetSymbol,
        NoFactorsFoundError,
        NoSetupFoundError,
        NotTradesFoundError
    }

    public abstract record InternalError(ErrorReason Reason, string Message);

    public record NotFoundError(string Id) : InternalError(ErrorReason.NotFound, $"Entity with ID {Id} not found.");
    
    
    public record WrongAssetSymbolError(string AssetName) : InternalError(ErrorReason.WrongAssetSymbol, $"Asset with name {AssetName} does not exist in system.");
    public record NoFactorsFoundError(IEnumerable<string> Errors) : InternalError(ErrorReason.NoFactorsFoundError, $"Factors errors occured.")
    {
        public IEnumerable<string> Errors { get; init; } = Errors;
    }
    public record NotTradesFoundError(IEnumerable<string> Errors) : InternalError(ErrorReason.NotTradesFoundError, $"Treades erros occured.")
    {
        public IEnumerable<string> Errors { get; init; } = Errors;
    }
    public record NoSetupFoundError(string SetupId) : InternalError(ErrorReason.NoSetupFoundError, $"Setup with ID {SetupId} not found.");


    public record ValidationError(IEnumerable<string> Errors) : InternalError(ErrorReason.ValidationFailed, "Validation errors occurred.")
    {
        public IEnumerable<string> Errors { get; init; } = Errors;
    }
}
