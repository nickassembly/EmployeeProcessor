using EmployeeProcessor.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProcessor.Data
{
    public class EmployeeProcessorDbContext : DbContext
    {
        public EmployeeProcessorDbContext(DbContextOptions<EmployeeProcessorDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeResponsibility>()
              .HasMany(emp => emp.Employees)
              .WithOne(emp => emp.EmployeeResponsibility);

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Compensation> Compensations { get; set; }
        public DbSet<EmployeeCompensation> EmployeeCompensation { get; set; }
        public DbSet<EmployeeResponsibility> EmployeeResponsibilities { get; set; }
    }
}
