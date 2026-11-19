namespace Domain.Models;

public class Doctor
{
    public int Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime HireDat { get; set; }
    public int? RoomId { get; set; }
    public Room? Room { get; set; }
}