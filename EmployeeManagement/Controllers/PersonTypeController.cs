using EmployeeManagement.Broker;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class PersonTypeController : Controller
    {
        private readonly PersonBroker _personBroker;
        public PersonTypeController(PersonBroker personBroker)
        {
            _personBroker = personBroker;
            
        }
        [HttpGet]
        public IActionResult AddPersonType()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPersonType(PersonTypeVM personTypeVM) 
        { 
            _personBroker.AddPersonType(personTypeVM);
            ModelState.Clear();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonTypes()
        {
            var personTypes = await _personBroker.GetPersonTypes();
            return View(personTypes);

        }
        [HttpGet]
        public IActionResult UpdatePersonType(Guid id)
        {
            var perType = _personBroker.GetPersonTypeById(id);
            if (perType != null)
            {
                var pertype = new PersonTypeVM
                {
                    Id = perType.Id,
                    Name = perType.Name
                };
                return View(pertype);
            }

            return RedirectToAction("GetPersonTypes");
        }
        [HttpPost]
        public IActionResult UpdatePersonType(PersonTypeVM perVM)
        {
            _personBroker.UpdatePersonType(perVM);
            return RedirectToAction("GetPersonTypes");
        }
        [HttpPost]
        public IActionResult DeletePersonType(PersonTypeVM personVM)
        {
            _personBroker.DeletePersonType(personVM);
            return RedirectToAction("GetPersonTypes");
        }

    }
}
