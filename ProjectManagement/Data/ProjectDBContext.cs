using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;
using System.Xml;

namespace ProjectManagement.Data
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Projects> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
     
    }
}
