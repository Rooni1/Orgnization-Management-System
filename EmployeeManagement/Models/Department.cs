namespace EmployeeManagement.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be empty/null Please Fill the Name");
                }
                else
                {
                    name = value;
                }
            }
        }
       public ICollection<Person> Persons { get; set; }
    }
}
