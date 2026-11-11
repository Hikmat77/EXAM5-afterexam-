namespace Application.DTOs;

public class UpdateDoctorDto
{
    public string Fullname {get; set;}=null!;
    public string Specialty {get; set;}=null!;
    public bool IsActive {get; set;}
    public DateTime HireDat {get; set;}
}
