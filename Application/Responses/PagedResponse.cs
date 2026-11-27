using System.Net;

namespace Application.Responces;

public class PagedResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public bool Success => (int)StatusCode < 400;
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = [];
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int? TotalCount { get; set; }
    public int? TotalPages => PageSize is > 0 && TotalCount.HasValue
        ? (int)(((long)TotalCount.Value + PageSize.Value - 1) / PageSize.Value)
        : null;
    public bool? HasPreviousPage => PageNumber.HasValue ? PageNumber.Value > 1 : null;
    public bool? HasNextPage => PageNumber.HasValue && TotalPages.HasValue
        ? PageNumber.Value < TotalPages.Value
        : null;

    public PagedResponse(HttpStatusCode statusCode, string message, T data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }

    public PagedResponse(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public PagedResponse(
        T data,
        int totalCount,
        int pageNumber,
        int pageSize,
        string message = "Success")
        : this(HttpStatusCode.OK, message, data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
    }

    public static PagedResponse<T> SuccessResponse(T data, string message = "Success")
    {
        return new PagedResponse<T>(HttpStatusCode.OK, message, data);
    }

    public static PagedResponse<T> FailureResponse(
        HttpStatusCode statusCode,
        string message,
        IEnumerable<string>? errors = null)
    {
        var response = new PagedResponse<T>(statusCode, message)
        {
            Errors = errors?.ToList() ?? []
        };
        return response;
    }
}
