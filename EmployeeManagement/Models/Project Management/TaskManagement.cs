using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models.Project_Management
{
   
    public class TaskManagement
    {
        
        public Guid Id { get; set; }
        //public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid personsId { get; set; }
        public Guid projectsId { get; set; }
        public Person persons { get; set; }
        public Project projects { get; set; }
        public ICollection<Activities> activities { get; set; }
    }
}
