namespace Domain.Filters;

public class PatientFilter : PaginationParameters
{
    public string? Fullname { get; set; }
    public string? Phone { get; set; }
    public bool? IsActive { get; set; }
}
