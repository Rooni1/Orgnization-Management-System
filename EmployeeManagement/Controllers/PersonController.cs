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
        [HttpGet]
        public async  Task<IActionResult> UpdatePerson(Guid id)
        {
            var person = _personBroker.GetPersonById(id);
            if (person != null)
            {
                var oldPerson = new PersonVM
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Address = person.Address,
                    Phone = person.Phone,
                    Email = person.Email,
                    Sallary = person.Sallary,
                    Designation = person.Designation,
                    StartDate = person.StartDate,
                    EndDate = person.EndDate,
                    DepartmentName = person.Departments.Name,
                    PersonTypeName = person.PersonTypes.Name,
                    DepartmentId = person.Departments.Id,
                    PersonTypesId = person.PersonTypes.Id

                };
                var perType = await _personBroker.GetPersonTypes();
                var department = await _departmentBroker.GetDepartments();
                ViewBag.PersonType = new SelectList(perType, "Id", "Name");
                ViewBag.Departments = new SelectList(department, "Id", "Name");
                
                return View(oldPerson);

            }

            return RedirectToAction("GetPersons");
        }
        [HttpPost]
        public IActionResult UpdatePerson(PersonVM perVM)
        {
            _personBroker.UpdatePerson(perVM);
            return RedirectToAction("GetPersons");
        }
        [HttpPost]
        public IActionResult DeletePerson(PersonVM personVM)
        {
            _personBroker.DeletePerson(personVM);
            return RedirectToAction("GetPersons");
        }
    }
}
