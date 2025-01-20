namespace PD.Shared.Models
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Data = data,
                ErrorMessage = null
            };
        }

        public static ApiResponse<T> Failure(string error)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Data = default,
                ErrorMessage = error
            };
        }
    }
}
