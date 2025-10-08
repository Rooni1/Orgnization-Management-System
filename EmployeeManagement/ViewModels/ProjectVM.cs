namespace EmployeeManagement.ViewModels
{
    public class ProjectVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string ManagerName { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientAdress { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string? DepartmentN{ get; set; }
        public Guid DepartmentId { get; set; }
    }
}
