using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.SharedKarnel.Entities
{
    public class BaseEntity : ParentEntity
    {
        public new Guid Id { get; set; }

    }
}
