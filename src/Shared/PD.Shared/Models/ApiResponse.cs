namespace PD.Shared.Models
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public static ApiResponse<T> Success(T data, string message = "Operation successful.")
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Error = message,
                Data = data,
                ErrorMessage = null
            };
        }

        public static ApiResponse<T> Failure(string error, string message = "Operation failed.")
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Error = message,
                Data = default,
                ErrorMessage = error
            };
        }
    }
}
