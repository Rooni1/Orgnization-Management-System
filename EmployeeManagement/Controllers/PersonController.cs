using EmployeeManagement.Broker;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagement.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonBroker _personBroker;
        private readonly DepartmentBroker _departmentBroker;
        public PersonController(PersonBroker personBroker, DepartmentBroker departmentBroker)
        {
            _personBroker = personBroker;
            _departmentBroker = departmentBroker;
            
        }
        [HttpGet]
        public async Task<IActionResult> AddPerson()
        {
            var perType = await _personBroker.GetPersonTypes();
            var department = await _departmentBroker.GetDepartments();
            ViewBag.PersonType = new SelectList(perType, "Id", "Name");
            ViewBag.Departments = new SelectList(department,"Id","Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonVM personVM)
        {
            _personBroker.AddPerson(personVM);
            var perType = await _personBroker.GetPersonTypes();
            ModelState.Clear();
            return RedirectToAction("AddPerson");
        }
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _personBroker.GetPersons();
            return View(persons);
        }
    }
}
