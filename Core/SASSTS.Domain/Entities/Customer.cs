using SASSTS2.Domain.Common;

namespace SASSTS2.Domain.Entities
{
    public class Customer : DeletetableEntity
    {
        public string IdentityNumber { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string DepartmentName { get; set; }
        public Roles Role { get; set; }

        public Account Account { get; set; }
        public Department Department { get; set; }

        public ICollection<PriceOffer> PriceOffers { get; set; }
        public ICollection<ProductRequest> ProductRequests { get; set; }
        public ICollection<PurchasedProduct> PurchasedProducts { get; set; }
        public ICollection<PurchaseRequest> PurchaseRequests { get; set; }

    }

   

}

