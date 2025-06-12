using System;

namespace LabAccessSystem.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; } = null!;

        public DateTime AssignedDate { get; set; }
    }
}