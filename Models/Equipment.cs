using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAccessSystem.Models;

public class Equipment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public string Type { get; set; } = string.Empty;

    [Display(Name = "Lab")]
    public int LabId { get; set; }

    [ForeignKey("LabId")]
    public Lab? Lab { get; set; }
}
