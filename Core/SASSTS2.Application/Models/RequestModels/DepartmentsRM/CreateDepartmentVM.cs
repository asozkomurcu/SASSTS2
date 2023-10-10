using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Models.RequestModels.DepartmentsRM
{
    public class CreateDepartmentVM
    {
        public int CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyName { get; set; }
    }
}
