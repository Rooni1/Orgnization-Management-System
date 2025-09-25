using EmployeeManagement.Data;
using EmployeeManagement.Models.Project_Management;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Broker
{
    public class ProjectBroker
    {
        private readonly PersonDbContext _personDbContext;
        public ProjectBroker(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        public void CreateProject(ProjectVM projectVM)
        {
            var department = _personDbContext.Departments.Find(projectVM.DepartmentId);
            var newProject = new Project 
            {
                Id = Guid.NewGuid(),
                Name = projectVM.Name,
                Description = projectVM.Description,
                StartDate = (DateTime)projectVM.StartDate,
                EndDate = (DateTime)projectVM.EndDate,
                ManagerName = projectVM.ManagerName,
                ClientName = projectVM.ClientName,
                ClientEmail = projectVM.ClientEmail,
                ClientAdress = projectVM.ClientAdress,
                Country = projectVM.Country,
                Status = projectVM.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
                DepartmentName = department.Name
            };
            _personDbContext.Projects.Add(newProject);
            _personDbContext.SaveChanges();
        }
        public async Task<List<ProjectVM>> GetProjects()
        {
            var projects = _personDbContext.Projects.ToList();
            var projectVMs = projects.Select(p => new ProjectVM
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                ManagerName = p.ManagerName,
                ClientName = p.ClientName,
                ClientEmail = p.ClientEmail,
                ClientAdress = p.ClientAdress,
                Country = p.Country,
                Status = p.Status,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                LastUpdatedAt = p.LastUpdatedAt,
                DepartmentName = p.DepartmentName
            }).ToList();

            return await Task.FromResult(projectVMs);
        }
    }
}
