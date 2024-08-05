using System;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.API.DTOs.UserDTO
{
    public class UpdateUserRequest
    {
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? DepartmentId { get; set; }
        public float? CoefficientsSalary { get; set; }
    }
}