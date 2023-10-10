using SASSTS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Domain.Entities
{
    public class Category : DeletetableEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
