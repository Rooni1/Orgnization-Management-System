using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EmployeeManagement.Broker
{
    public class PersonBroker
    {
        readonly PersonDbContext _personDbContext;
        public PersonBroker(PersonDbContext personDbContext)
        {
            _personDbContext = personDbContext;
        }
        public void AddPerson(PersonVM personVM)
        {
            
            var perTypeId = GetPersonTypeById(personVM.Id);
            CreatingRelventObject(personVM);
          
        }
        private void CreatingRelventObject(PersonVM personVM)
        {

                
                var newPerson = new Person
                {
                    Id = new Guid(),
                    FirstName = personVM.FirstName,
                    LastName = personVM.LastName,
                    Phone = personVM.Phone,
                    Email = personVM.Email,
                    Sallary = personVM.Sallary,
                    StartDate = (DateTime)personVM.StartDate,
                    EndDate = (DateTime)personVM.EndDate,
                    Designation = personVM.Designation,
                    Address = personVM.Address,
                    DepartmentsId = personVM.DepartmentId,
                    PersonTypeId = personVM.PersonTypesId
                };
                _personDbContext.Persons.Add(newPerson);
                _personDbContext.SaveChanges();           
        }
        public async Task<List<PersonVM>> GetPersons()
        {
            var persons =  await _personDbContext.Persons.Include(y => y.Departments).Include(x => x.PersonTypes).ToListAsync();
            var personsList = new List<PersonVM>();
           


            foreach (var x in persons) 
            {
                var personVM = new PersonVM(); 
                personVM.Id = x.Id;
                personVM.FirstName = x.FirstName;
                personVM.LastName = x.LastName;
                personVM.Phone = x.Phone;
                personVM.Email = x.Email;
                personVM.Sallary = x.Sallary;
                personVM.StartDate = x.StartDate;
                personVM.EndDate = x.EndDate;
                personVM.Designation = x.Designation;
                personVM.Address = x.Address;
                personVM.DepartmentName = x.Departments.Name;
                personVM.PersonTypeName = x.PersonTypes.Name;
                personsList.Add(personVM);
            }

          return personsList;
        }
        public Person GetPersonById(Guid id)
        {
            var person = _personDbContext.Persons.Include(x=>x.Departments).Include(y=>y.PersonTypes).FirstOrDefault(x => x.Id == id);
            return person;
        }
        public void UpdatePerson(PersonVM personVM)
        {
            var person = _personDbContext.Persons.Find(personVM.Id);
            
            if (person != null)
            {
                person.FirstName = personVM.FirstName;
                person.LastName = personVM.LastName;
                person.Phone = personVM.Phone;
                person.Email = personVM.Email;
                person.Sallary = personVM.Sallary;
                person.StartDate = (DateTime)personVM.StartDate;
                person.EndDate = (DateTime)personVM.EndDate;
                person.Designation = personVM.Designation;
                person.Address = personVM.Address;
                person.DepartmentsId = personVM.DepartmentId;
                person.PersonTypeId = personVM.PersonTypesId;
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

        public void AddPersonType(PersonTypeVM personTVM)
        {
            var newPersonType = new PersonType
            {
                Id = Guid.NewGuid(),
                Name = personTVM.Name
            };
            _personDbContext.PersonTypes.Add(newPersonType);
            _personDbContext.SaveChanges();

        }
        public async Task <List<PersonTypeVM>> GetPersonTypes() 
        {
            var personTypes = await _personDbContext.PersonTypes.Select(x => new PersonTypeVM { Id = x.Id, Name = x.Name }).ToListAsync();
            return personTypes;
        }
        public PersonType GetPersonTypeById(Guid id)
        {
            var personType = _personDbContext.PersonTypes.FirstOrDefault(x=> x.Id==id);
            return personType;
        }
        public void UpdatePersonType(PersonTypeVM personTypeVM)
        {
            var perType = _personDbContext.PersonTypes.FirstOrDefault(x=>x.Id==personTypeVM.Id);
            if (perType != null) 
            {
                perType.Name = personTypeVM.Name;
                _personDbContext.SaveChanges();
            }
        }

        public void DeletePersonType(PersonTypeVM personType) 
        { 
            var perType = _personDbContext.PersonTypes.Find(personType.Id);
            if(perType != null)
            {
                _personDbContext.PersonTypes.Remove(perType);
                _personDbContext.SaveChanges();
            }
        }
        public void DeletePerson(PersonVM personVM)
        {
            var person = _personDbContext.Persons.Find(personVM.Id);
            if (person != null)
            {
                _personDbContext.Persons.Remove(person);
                _personDbContext.SaveChanges();
            }
        }

    }
}
