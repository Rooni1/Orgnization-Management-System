using EmployeeManagement.Data;
using EmployeeManagement.Models.Project_Management;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using Task = EmployeeManagement.Models.Project_Management.TaskManagement;

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
                DepartmentN = p.DepartmentName
            }).ToList();

            return projectVMs;
        }
        public ProjectVM GetProjectById(Guid id)
        {
            var oldproject = _personDbContext.Projects.FirstOrDefault(x => x.Id == id);
            var projectVMs = new ProjectVM
            {
                Id = oldproject.Id,
                Name = oldproject.Name,
                Description = oldproject.Description,
                StartDate = oldproject.StartDate,
                EndDate = oldproject.EndDate,
                ManagerName = oldproject.ManagerName,
                ClientName = oldproject.ClientName,
                ClientEmail = oldproject.ClientEmail,
                ClientAdress = oldproject.ClientAdress,
                Country = oldproject.Country,
                Status = oldproject.Status,
                CreatedAt = oldproject.CreatedAt,
                UpdatedAt = oldproject.UpdatedAt,
                LastUpdatedAt = oldproject.LastUpdatedAt,
                DepartmentN = oldproject.DepartmentName
            };

            return projectVMs;
        }
        public void UpdateProject(ProjectVM projectVM)
        {
            var department = _personDbContext.Departments.Find(projectVM.DepartmentId);
            var project = _personDbContext.Projects.Find(projectVM.Id);
            if (project != null)
            {
                project.Name = projectVM.Name;
                project.Description = projectVM.Description;
                project.StartDate = (DateTime)projectVM.StartDate;
                project.EndDate = (DateTime)projectVM.EndDate;
                project.ManagerName = projectVM.ManagerName;
                project.ClientName = projectVM.ClientName;
                project.ClientEmail = projectVM.ClientEmail;
                project.ClientAdress = projectVM.ClientAdress;
                project.Country = projectVM.Country;
                project.Status = projectVM.Status;
                project.UpdatedAt = projectVM.UpdatedAt;
                project.LastUpdatedAt = DateTime.Now;
                project.DepartmentName = projectVM.DepartmentN;

            }
            _personDbContext.Update(project);
            _personDbContext.SaveChanges();
        }
        public void DeleteProject(ProjectVM projectVM)
        {
            var project = _personDbContext.Projects.Find(projectVM.Id);
            if (project != null)
            {
                _personDbContext.Projects.Remove(project);
                _personDbContext.SaveChanges();
            }
        }
        public void CreateTask(TaskVM taskvm)
        {
            var newTask = new TaskManagement
            {
                Id = Guid.NewGuid(),
                Description = taskvm.Description,
                personsId = taskvm.PersonId,
                projectsId = taskvm.ProjectId,
                Status = taskvm.Status,
                StartDate = taskvm.StartDate,
                DueDate = taskvm.DueDate
            };
            _personDbContext.TaskManagement.Add(newTask);
            _personDbContext.SaveChanges();
        }
        public async Task<List<TaskVM>> GetTasks()
        {
            var tasks = _personDbContext.TaskManagement.Include(t => t.persons).Include(t => t.projects).ToList();
            var taskList = new List<TaskVM>();
            foreach (var task in tasks)
            {
                var taskVM = new TaskVM();
                taskVM.Id = task.Id;
                taskVM.PersonName = task.persons.FirstName + " " + task.persons.LastName;
                taskVM.ProjectName = task.projects.Name;
                taskVM.Description = task.Description;
                taskVM.Status = task.Status;
                taskVM.StartDate = task.StartDate;
                taskVM.DueDate = task.DueDate;
                taskList.Add(taskVM);
            }

            return taskList;
        }
        public TaskVM GetTaskById(Guid id)
        {
            var task = _personDbContext.TaskManagement.Include(t => t.persons).Include(t => t.projects).FirstOrDefault(x => x.Id == id);
            var taskVM = new TaskVM();
            taskVM.Id = task.Id;
            taskVM.PersonName = task.persons.FirstName + " " + task.persons.LastName;
            taskVM.ProjectName = task.projects.Name;
            taskVM.Description = task.Description;
            taskVM.Status = task.Status;
            taskVM.StartDate = task.StartDate;
            taskVM.DueDate = task.DueDate;
            taskVM.PersonId = task.personsId;
            taskVM.ProjectId = task.projectsId;
            return taskVM;
        }
        public void UpdateTask(TaskVM taskvm)
        {
            var CurrentTask = _personDbContext.TaskManagement.Find(taskvm.Id);
            if (CurrentTask != null)
            {
                CurrentTask.Description = taskvm.Description;
                CurrentTask.personsId = taskvm.PersonId;
                CurrentTask.projectsId = taskvm.ProjectId;
                CurrentTask.Status = taskvm.Status;
                CurrentTask.StartDate = taskvm.StartDate;
                CurrentTask.DueDate = taskvm.DueDate;
            }
            _personDbContext.Update(CurrentTask);
            _personDbContext.SaveChanges();
        }
        public void DeleteTask(TaskVM taskvm)
        {
            var CurrentTask = _personDbContext.TaskManagement.Find(taskvm.Id);
            if (CurrentTask != null)
            {
                _personDbContext.TaskManagement.Remove(CurrentTask);
                _personDbContext.SaveChanges();
            }
        }
        public void CreateActivity(ActivityVM activityVM)
        {

            var newActivity = new Activities
            {
                Id = Guid.NewGuid(),
                Description = activityVM.Description,
                Todo = activityVM.Todo,
                WorkInProcess = activityVM.WorkInProcess,
                Done = activityVM.Done,
                StartDate = activityVM.StartDate,
                EndDate = activityVM.EndDate,
                TaskManageId = activityVM.TaskManagementId
            };
            _personDbContext.Activities.Add(newActivity);
            _personDbContext.SaveChanges();
        }
    }
}
