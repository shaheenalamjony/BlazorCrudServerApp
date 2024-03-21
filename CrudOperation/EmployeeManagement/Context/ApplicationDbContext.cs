using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships between Employee, Designation, and Department

            modelBuilder.Entity<Designation>()
                .HasOne(d => d.Department)
                .WithMany(d => d.Designations)
                .HasForeignKey(d => d.DepartmentId)
                .IsRequired();

        }
    }
}