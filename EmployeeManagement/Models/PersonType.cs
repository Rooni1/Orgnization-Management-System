namespace EmployeeManagement.Models
{
    public class PersonType
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
