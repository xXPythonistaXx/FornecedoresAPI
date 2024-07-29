namespace FornecedoresAPI.Models
{
    public class Result<T>
    {
        public T? Value { get; private set; }
        public string? ErrorMessage { get; private set; }
        public bool IsSuccess => ErrorMessage == null;

        private Result(T? value)
        {
            Value = value;
            ErrorMessage = null;
        }

        private Result(string errorMessage)
        {
            Value = default;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T? value) => new Result<T>(value);
        public static Result<T> Fail(string errorMessage) => new Result<T>(errorMessage);
    }

    public class Result
    {
        public string? ErrorMessage { get; private set; }
        public bool IsSuccess => ErrorMessage == null;

        private Result(string? errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public static Result Success() => new Result(null);
        public static Result Fail(string errorMessage) => new Result(errorMessage);
    }
}
