using EmployeeManagement.Broker;
using EmployeeManagement.Models.Departments;
using EmployeeManagement.Models.Project_Management;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly DepartmentBroker _departmentBroker;
        private readonly ProjectBroker _projectBroker;
        private readonly PersonBroker _personBroker;
        public ProjectController(DepartmentBroker departmentBroker, ProjectBroker projectBroker, PersonBroker personBroker)
        {
            _departmentBroker = departmentBroker;
            _projectBroker = projectBroker;
            _personBroker = personBroker;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            var department = await _departmentBroker.GetDepartments();
            ViewBag.Departments = new SelectList(department, "Id", "Name");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectVM projectVM)
        {

            if (ModelState.IsValid)
            {
                // Call the broker to create the project
                _projectBroker.CreateProject(projectVM);
                ModelState.Clear();
                return RedirectToAction("CreateProject");
            }

            var departments = await _departmentBroker.GetAllDepartments();
            ViewBag.Departments = new SelectList(departments, "id", "Name");
            return View(projectVM);
        }
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectBroker.GetProjects();
            return View(projects);
        }
        [HttpGet]
        public IActionResult UpdateProject(Guid id)
        {
            var peroject = _projectBroker.GetProjectById(id);
            if (peroject != null)
            {
                return View(peroject);
            }

            return RedirectToAction("UpdateProject");
        }
        [HttpPost]
        public IActionResult UpdateProject(ProjectVM projectVM)
        {
            _projectBroker.UpdateProject(projectVM);
            return RedirectToAction("GetProjects");
        }
        [HttpPost]
        public IActionResult DeleteProject(ProjectVM projectVM)
        {
            _projectBroker.DeleteProject(projectVM);
            return RedirectToAction("GetProjects");
        }
        [HttpGet]
        public async Task<IActionResult> CreateTask()
        {
            var projects = await _projectBroker.GetProjects();
            ViewBag.Projects = new SelectList(projects, "Id", "Name");
            var persons = await _personBroker.GetPersons();

            var personList = new List<PersonVM>();
            foreach (var person in persons)
            {
                var personVM = new PersonVM();
                personVM.Id = person.Id;
                personVM.FirstName = person.FirstName + " " + person.LastName;
                personList.Add(personVM);
            }

            ViewBag.Persons = new SelectList(personList, "Id", "FirstName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskVM taskVM)
        {
            _projectBroker.CreateTask(taskVM);
            return RedirectToAction("CreateTask");

        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {

            var tasks = await _projectBroker.GetTasks();
            return View(tasks);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTask(Guid id)
        {
            var CurrentTask = _projectBroker.GetTaskById(id);
            if (CurrentTask != null)
            {

                var persons = await _personBroker.GetPersons();
                var personList = new List<PersonVM>();
                foreach (var person in persons)
                {
                    var personVM = new PersonVM();
                    personVM.Id = person.Id;
                    personVM.FirstName = person.FirstName + " " + person.LastName;
                    personList.Add(personVM);
                }

                ViewBag.Persons = new SelectList(personList, "Id", "FirstName");
                return View(CurrentTask);

            }

            return RedirectToAction("GetTasks");
        }
        [HttpPost]
        public IActionResult UpdateTask(TaskVM taskVM)
        {
            _projectBroker.UpdateTask(taskVM);
            return RedirectToAction("GetTasks");
        }
        [HttpPost]
        public IActionResult DeleteTask(TaskVM taskVM)
        {
            _projectBroker.DeleteTask(taskVM);
            return RedirectToAction("GetTasks");
        }
        [HttpGet]
        public IActionResult CreateActivity(Guid id)
        {
            var tasks = _projectBroker.GetTaskById(id);
            var activityVM = new ActivityVM
            {
                TaskManagementId = tasks.Id,
                TaskDescription = tasks.Description
            };

            return View(activityVM);
        }
        [HttpPost]
        public IActionResult CreateActivity(ActivityVM activityVM)
        {
            _projectBroker.CreateActivity(activityVM);
            return RedirectToAction("GetTasks");
        }
    }
}
