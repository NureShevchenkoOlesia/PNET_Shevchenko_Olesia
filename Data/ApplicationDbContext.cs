using Microsoft.EntityFrameworkCore;
using LabAccessSystem.Models;

namespace LabAccessSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}

    public DbSet<Lab> Labs => Set<Lab>();
    public DbSet<Equipment> Equipment => Set<Equipment>();
    public DbSet<AccessLog> AccessLogs => Set<AccessLog>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
}
