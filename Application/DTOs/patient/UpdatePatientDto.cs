namespace Application.DTOs;

public class UpdatePatientDto
{
    public string Fullname {get; set;}=null!;
    public string Phone {get; set;}=null!;
    public DateTime? BirthDate {get; set;}
    public bool IsActive {get; set;}
}
