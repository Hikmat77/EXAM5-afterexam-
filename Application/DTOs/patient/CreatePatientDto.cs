namespace Application.DTOs;

public class CreatePatientDto
{
    public string Fullname {get; set;}=null!;
    public string Phone {get; set;}=null!;
    public DateTime? BirthDate {get; set;}
}
