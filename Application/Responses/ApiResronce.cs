using System.Net;

namespace Application.Responces;

public class ApiResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public ApiResponse(HttpStatusCode httpStatusCode, string message, T data)
    {
        StatusCode = httpStatusCode;
        Message = message;
        Data = data;
    }
    public ApiResponse(HttpStatusCode httpStatusCode, string message)
    {
        StatusCode = httpStatusCode;
        Message = message;
    }
}