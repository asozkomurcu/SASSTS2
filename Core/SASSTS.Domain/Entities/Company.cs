using SASSTS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Domain.Entities
{
    public class Company : DeletetableEntity
    {
        public Company() 
        {
            Departments = new List<Department>();
        }

        public string CompanyName { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
