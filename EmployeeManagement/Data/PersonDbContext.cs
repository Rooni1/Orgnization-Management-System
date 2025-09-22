using EmployeeManagement.Models;
using EmployeeManagement.Models.Departments;
using EmployeeManagement.Models.Project_Management;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class PersonDbContext:DbContext
    {
        public PersonDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
