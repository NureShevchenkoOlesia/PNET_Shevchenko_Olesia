using System.Collections.Generic;

namespace LabAccessSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Position { get; set; } = null!;

        public List<Assignment> Assignments { get; set; } = new();
    }
}