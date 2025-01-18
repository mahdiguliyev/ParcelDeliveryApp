namespace PD.Shared.Models
{
    public class DomainError(string? errorMessage, ErrorType errorType)
    {
        public string? ErrorMessage { get; } = errorMessage;
        public ErrorType ErrorType { get; } = errorType;
        public static DomainError DataError(string? message = "Given data is not correct") => new(message, ErrorType.DataError);
        public static DomainError BusinessError(string? message = "Conflict operation") => new(message, ErrorType.BusinessError);
    }

    public enum ErrorType
    {
        DataError,
        BusinessError
    }
}
