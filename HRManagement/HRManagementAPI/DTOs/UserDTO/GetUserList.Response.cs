using HRManagement.Domain.AggregateModels.UserAggregate;

namespace HRManagement.API.DTOs.UserDTO
{
    public class GetUserListResponse
    {
        public IEnumerable<UserDto>? Users { get; set; }

    
}

    public class UserDto
     {
         public Guid UserId { get; set; }
         public string UserName { get; set; } = string.Empty;
         public string FirstName { get; set; } = string.Empty;
         public string LastName { get; set; } = string.Empty;
         public string Address { get; set; } = string.Empty;
         public DateTime? BirthDate { get; set; }
         public int DepartmentId { get; set; }
         public float CoefficientsSalary { get; set; }
     }
}
