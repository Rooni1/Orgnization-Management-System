using EmployeeManagement.Broker;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagement.Controllers
{
    public class DepartmentController : Controller

    {
        private readonly DepartmentBroker _broker;
        public DepartmentController(DepartmentBroker broker)
        {
            _broker = broker;
        }

        [HttpGet]
        public IActionResult AddDepart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDepart(DepartmentVM departVM)
        {
            _broker.AddDepartment(departVM);
            ModelState.Clear();

            return RedirectToAction("GetDepartments");
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments() 
        {
            
            var departVM = await _broker.GetDepartments();
             return View(departVM);
        }
        [HttpGet]
        public IActionResult UpdateDepartment(Guid id)
        {
            var depat = _broker.GetDepartmentById(id);
            if(depat != null)
            {
                var depatVM = new DepartmentVM
                {
                    Id = depat.Id,
                    Name = depat.Name
                };
                return View(depatVM);
            }
            
            return RedirectToAction("GetDepartments");
        }
        [HttpPost]
        public IActionResult UpdateDepartment(DepartmentVM departVM)
        {
            _broker.UpdateDepartment(departVM);
            return RedirectToAction("GetDepartments");
        }

        [HttpPost]
        public IActionResult DeleteDepartment(DepartmentVM departVM)
        { 
            _broker.DeleteDepartments(departVM);
            return RedirectToAction("GetDepartments");
        }
    }
}
