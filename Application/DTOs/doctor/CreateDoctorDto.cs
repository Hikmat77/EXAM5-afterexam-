namespace Application.DTOs;

public class CreateDoctorDto
{
    public string Fullname {get; set;}=null!;
    public string Specialty {get; set;}=null!;
    public DateTime HireDat {get; set;}
}
