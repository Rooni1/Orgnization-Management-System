namespace EmployeeManagement.ViewModels
{
    public class PersonVM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Sallary { get; set; }
        public string DepartmentName { get; set; }
        public string PersonTypeName { get; set; }
        public Guid PersonTypesId { get; set; }
        public Guid DepartmentId { get; set; }
       
       
    }
}
