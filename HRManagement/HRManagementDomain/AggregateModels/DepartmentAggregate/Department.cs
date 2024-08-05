using HRManagement.Domain.AggregateModels.UserAggregate;
using HRManagement.SharedKarnel.Entities;

namespace HRManagement.Domain.AggregateModels.DepartmentAggregate
{
    public class Department : ParentEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<User>? Users { get; set; }

    }
}
