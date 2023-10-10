using SASSTS2.Domain.Common;

namespace SASSTS2.Domain.Entities
{
    public class Department : DeletetableEntity
    {
        public Department()
        {
            Customers = new List<Customer>();
        }

        public int CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyName { get; set; }

        public Company Company { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
