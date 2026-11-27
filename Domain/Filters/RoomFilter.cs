namespace Domain.Filters;

public class RoomFilter : PaginationParameters
{
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
}
