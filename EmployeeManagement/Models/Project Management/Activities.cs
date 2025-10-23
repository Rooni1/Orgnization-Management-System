namespace EmployeeManagement.Models.Project_Management
{
    public class Activities
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Todo { get; set; }
        public string WorkInProcess { get; set; }
        public string Done { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TaskManageId { get; set; }
        public TaskManagement TaskManage{ get; set; }

    }
}
