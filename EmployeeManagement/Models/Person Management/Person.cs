using System.ComponentModel.DataAnnotations.Schema;
using EmployeeManagement.Models.Departments;
using EmployeeManagement.Models.Project_Management;

namespace EmployeeManagement.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Sallary { get; set; }
        public string Designation { get; set; }
        public Guid DepartmentsId { get; set; }
        //[ForeignKey("PersonTypeId")]
        public Guid PersonTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public string DepartmentName { get; set; }
        //public string PersonTypeName { get; set; }
        public Department Departments { get; set; }
        public PersonType PersonTypes { get; set; }
        public ICollection<TaskManagement> TaskMang { get; set; }


    }
}
