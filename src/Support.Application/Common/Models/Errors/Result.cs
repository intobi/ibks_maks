namespace Support.Application.Errors
{
    public class Result<TError, TValue> where TError : InternalError
    {
        private readonly TError? _error;
        private readonly TValue? _value;

        public Result(TValue value)
        {
            _value = value;
        }

        public Result(TError error)
        {
            _error = error;
        }

        public TValue? Value => _value;
        public TError? Error => _error;

        public bool IsSuccess => _value is not null;

        public TResult Match<TResult>(Func<TError, TResult> errorFunc, Func<TValue, TResult> successFunc)
        {
            return IsSuccess ? successFunc(_value!) : errorFunc(_error!);
        }

        public static implicit operator Result<TError, TValue>(TValue value) => new(value);
        public static implicit operator Result<TError, TValue>(TError error) => new(error);
    }
}
