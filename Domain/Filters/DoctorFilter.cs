namespace Domain.Filters;

public class DoctorFilter : PaginationParameters
{
    public string? Fullname { get; set; }
    public string? Specialty { get; set; }
    public int? RoomId { get; set; }
    public bool? IsActive { get; set; }
}
