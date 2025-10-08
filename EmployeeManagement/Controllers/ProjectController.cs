using EmployeeManagement.Broker;
using EmployeeManagement.Models.Departments;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly DepartmentBroker _departmentBroker;
        private readonly ProjectBroker _projectBroker;
        public ProjectController(DepartmentBroker departmentBroker, ProjectBroker projectBroker)
        {
            _departmentBroker = departmentBroker;
            _projectBroker = projectBroker;

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
    }
}
