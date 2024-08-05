namespace HRManagement.API.DTOs.UserDTO
{
    public class AddUserRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public float CoefficientsSalary { get; set; }
    }
}