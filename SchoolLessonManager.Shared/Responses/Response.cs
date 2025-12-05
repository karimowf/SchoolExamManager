using System.Text.Json.Serialization;

namespace SchoolLessonManager.Shared.Responses
{
    public class Response<T>
    {
        public T? Data { get; set; }

        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSuccessfully { get; set; }

        public List<string>? Errors { get; set; }

        public bool IsSuccess { get; set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T>()
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessfully = true
            };
        }

        public static Response<T> Success(T data, int statusCode, bool isSuccess)
        {
            return new Response<T>()
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessfully = true,
                IsSuccess = isSuccess
            };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T>()
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccessfully = false,
                IsSuccess = false
            };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T>()
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode,
                IsSuccessfully = false,
                IsSuccess = false
            };
        }

        public static Response<T> Fail(T data, int statusCode)
        {
            return new Response<T>()
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccessfully = false,
                IsSuccess = false
            };
        }
    }
}
