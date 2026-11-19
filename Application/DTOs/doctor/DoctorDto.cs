namespace Application.DTOs;

public class DoctorDto
{
    public int Id {get; set;}
    public string Fullname {get; set;}=null!;
    public string Specialty {get; set;}=null!;
    public bool IsActive {get; set;}
    public DateTime HireDat {get; set;}
    public int? RoomId {get; set;}
    public RoomDto? Room {get; set;}
}
