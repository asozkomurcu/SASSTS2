using SASSTS2.Domain.Common;

namespace SASSTS2.Domain.Entities
{
    public class PurchaseRequest : DeletetableEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Status Status { get; set; }

        public Customer Customer { get; set; }
        public ProductRequest ProductRequest { get; set; }

        public ICollection<PriceOffer> PriceOffers { get; set; }
        //public ICollection<ProductRequest> ProductRequests { get; set; }
        public ICollection<PurchasedProduct> PurchasedProducts { get; set; }
    }

    
}
//satın alım talebi
//	talep id
//	talep oluşturan kullanıcı id
//  kullanıcı adı