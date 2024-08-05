namespace HRManagement.API.DTOs.DepartmentDTO
{
    public class GetDepartmentsResponse
    {
        public IEnumerable<DepartmentDto>? Departments { get; set; }
    }

    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }= string.Empty;
        public string Description { get; set; }= string.Empty;
    }
}
