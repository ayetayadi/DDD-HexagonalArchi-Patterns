using HRManagement.Domain.AggregateModels.DepartmentAggregate;
using HRManagement.SharedKarnel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Domain.AggregateModels.UserAggregate
{
    public class User : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public float CoefficientsSalary { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
