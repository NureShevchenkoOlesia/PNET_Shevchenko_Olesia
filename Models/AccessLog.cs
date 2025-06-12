using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAccessSystem.Models;

public class AccessLog
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty; 

    public string EntityName { get; set; } = string.Empty; 

    public int? EntityId { get; set; } 

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
