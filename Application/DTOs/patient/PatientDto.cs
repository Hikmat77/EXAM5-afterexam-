namespace Application.DTOs;

public class PatientDto
{
    public int Id {get; set;}
    public string Fullname {get; set;}=null!;
    public string Phone {get; set;}=null!;
    public DateTime? BirthDate {get; set;}
    public bool IsActive {get; set;}
    public DateTime CreatedAt {get; set;}
}
