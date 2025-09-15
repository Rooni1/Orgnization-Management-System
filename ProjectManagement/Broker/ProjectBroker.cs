using EmployeeManagement.Broker;
using EmployeeManagement.Controllers;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Models;
using ProjectManagement.ViewModel;

namespace ProjectManagement.Broker
{
    public class ProjectBroker
    {
        readonly ProjectDBContext _projectDbContext;
        readonly DepartmentBroker _departmentBroker;
       
        public ProjectBroker(ProjectDBContext projectDbContext,DepartmentBroker departmentBroker)
        {
            _projectDbContext = projectDbContext;
            _departmentBroker = departmentBroker;
           
        }
       
        public void AddProject(ProjectViewModel projectVM)
        {
            //var departments = _departmentBroker.GetDepartments();
            var department = _projectDbContext.Departments.FirstOrDefault(x => x.Id == projectVM.DepartmentId);
            var newProject = new Projects()
            {
               Id= new Guid(),
               Name= projectVM.Name,
               Description= projectVM.Description,
               StartDate= (DateTime)projectVM.StartDate,
               EndDate= (DateTime)projectVM.EndDate,
               ManagerName= projectVM.ManagerName,
               ClientName= projectVM.ClientName,
               ClientEmail= projectVM.ClientEmail,
               ClientAdress= projectVM.ClientAdress,
               Country= projectVM.Country,
               CreatedAt= DateTime.Now,
               UpdatedAt= DateTime.Now,
               LastUpdatedAt= DateTime.Now,
               Department= department.Name,
               Status= projectVM.Status
            };
            // Save newProject to the database
            _projectDbContext.Projects.Add(newProject);
            _projectDbContext.SaveChanges();
        }
        public Task<List<ProjectViewModel>> GetProjects() 
        {
            // Implementation for retrieving projects
            return Task.FromResult(new List<ProjectViewModel>());
        }
        //public async Task<List<Department>> GetAllDepartments()
        //{
        //    var departments = await _projectDbContext.Departments.Select(x => new Department
        //    {
        //        Id = x.Id,
        //        Name = x.Name
        //    }).ToListAsync();
        //    return departments;
        //}
    }
}
