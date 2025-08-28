using EmployeeManagement.Broker;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectManagement.Controllers
{
    public class ProjectController : Controller
    {
        public readonly DepartmentBroker _departmentBroker;
        public ProjectController(DepartmentBroker departmentBroker)
        {
            _departmentBroker= departmentBroker;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            var departments = await _departmentBroker.GetDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View();
        }
    }
}
