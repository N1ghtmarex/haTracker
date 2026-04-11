namespace Core.Utils;

public class Result<T>(bool isSuccess, T? value, string error)
{
    public bool IsSuccess { get; } = isSuccess;
    public bool IsFailure => !IsSuccess;
    public T? Value { get; } = value;
    public string Error { get; } = error;
}

public static class Result
{
    public static Result<T> Success<T>(T value) => new(true, value, string.Empty);
    public static Result<T> Failure<T>(string error) => new(false, default, error);
}
