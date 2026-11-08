namespace Domain.Models;

public class Patient
{
    public int Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreateAt { get; set; }
}