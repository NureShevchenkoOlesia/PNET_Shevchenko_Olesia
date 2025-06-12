using System.ComponentModel.DataAnnotations;
namespace LabAccessSystem.Models;

public class Lab
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Location { get; set; } = string.Empty;
    
    public List<Equipment> EquipmentList { get; set; } = new();
}
