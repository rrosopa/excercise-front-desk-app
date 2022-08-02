using System.Net;

namespace Application.Common.Models
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public string ErrorMessage { get; private set; }
        public int StatusCode { get; private set; } = (int)HttpStatusCode.OK;

        public Result(T data)
        {
            Data = data;
        }

        public Result(string errorMessage, int statusCode)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
        }

        public static Result<T> Ok(T data)
        {
            return new Result<T>(data);
        }

        public static Result<T> Error(string errorMessage, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new Result<T>(errorMessage, statusCode);
        }

        public static Result<T> NotFound(string errorMessage)
        {
            return new Result<T>(errorMessage, (int)HttpStatusCode.NotFound);
        }

    }
}
