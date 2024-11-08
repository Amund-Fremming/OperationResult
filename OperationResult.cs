namespace OperationResult
{
    /// <summary>
    /// Represents the result of an operation, encapsulating success or failure state,
    /// optional data, a message, and an exception if applicable.
    /// </summary>
    /// <param name="Data">Generic data on sucess.</param>
    /// <param name="Message">Failure message to the enduser.</param>
    /// <param name="Exception">Exception thrown, used maily for debugging.</param>
    public record OperationResult<T>(T? Data, string Message = "", Exception? Exception = null)
    {
        public bool IsSuccess = Data is not null;

        public static OperationResult<T> Success(T data) => new(data);
        public static OperationResult<T> Failure(string message, Exception exception) => new(default, message, exception);
    }
}