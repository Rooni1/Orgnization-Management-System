using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

namespace EmployeeManagement.Broker
{
    public class DepartmentBroker
    {
        private readonly PersonDbContext _personDbContext;
        public DepartmentBroker(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        public DepartmentBroker()
        {
            
        }
        public void AddDepartment(DepartmentVM departVM)
        {
              
            var newDepartment = new Department 
            { 
                Id = Guid.NewGuid(),
                Name = departVM.Name
            };
            _personDbContext.Departments.Add(newDepartment);
            _personDbContext.SaveChanges();
           

        }
        public async Task <List<DepartmentVM>> GetDepartments()
        {
            var departments =  await _personDbContext.Departments.Select(x=> new DepartmentVM { Id = x.Id,Name =x.Name}).ToListAsync();
           
            return departments;
        }
        public async Task<List<Department>> GetAllDepartments()
        {
            var allDepartments = await _personDbContext.Departments.Select(x => new Department { Name = x.Name} ).ToListAsync();
            return allDepartments;
        }
        public Department GetDepartmentById(Guid id)
        {
            var departmet = _personDbContext.Departments.FirstOrDefault(x => x.Id == id);
            return departmet;
        }
        public void UpdateDepartment(DepartmentVM departmentVM) 
        {
           var department = _personDbContext.Departments.Find(departmentVM.Id);
           if(department != null)
            {
                department.Name = departmentVM.Name;
                _personDbContext.SaveChanges();
               
            }
                   
        }
        public void DeleteDepartments(DepartmentVM depatVM) 
        {
            var department = _personDbContext.Departments.Find(depatVM.Id);
            if (department != null)
            {
                _personDbContext.Departments.Remove(department);
                _personDbContext.SaveChanges();   
            }
        }
    }
}
