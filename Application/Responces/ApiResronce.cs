using System.Net;

namespace Application.Responces;

public class ApiResronce<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public ApiResronce(HttpStatusCode httpStatusCode, string message, T data)
    {
        StatusCode = httpStatusCode;
        Message = message;
        Data = data;
    }
    public ApiResronce(HttpStatusCode httpStatusCode, string message)
    {
        StatusCode = httpStatusCode;
        Message = message;
    }
}