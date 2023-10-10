using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Domain.Common
{
    public abstract class DeletetableEntity : AuditableEntity
    {
        public bool? IsDeleted { get; set; }
    }
}
