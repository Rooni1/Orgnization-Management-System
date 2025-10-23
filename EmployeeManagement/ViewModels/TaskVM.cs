namespace EmployeeManagement.ViewModels
{
    public class TaskVM
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string PersonName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ProjectId { get; set; }
        public Guid PersonId { get; set; }
    }
}
