namespace Domain.Models;

public class PagedResult<T>(
    IReadOnlyList<T> items,
    int totalCount,
    int pageNumber,
    int pageSize)
{
    public IReadOnlyList<T> Items { get; } = items;
    public int TotalCount { get; } = totalCount;
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
}
