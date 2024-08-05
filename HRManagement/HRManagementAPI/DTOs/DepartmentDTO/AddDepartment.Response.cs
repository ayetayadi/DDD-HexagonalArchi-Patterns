namespace HRManagement.API.DTOs.DepartmentDTO
{
    public class AddDepartmentResponse
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
    }
}
