using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Room
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<Doctor> Doctors { get; set; } = [];
}