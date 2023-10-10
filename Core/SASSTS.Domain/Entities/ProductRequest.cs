using SASSTS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Domain.Entities
{
    public class ProductRequest : DeletetableEntity
    {
        //public ProductRequest() 
        //{
        //    Products = new List<Product>();
        //}
        public int ProductId { get; set; }
        public int PurchaseRequestId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Amount { get; set; }

        public Product Product { get; set; }
        public PurchaseRequest PurchaseRequest { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
//satın alınacak ürünün
//	ürün id
//	talep id
//	talep eden kullanıcı id
//	talep eden kullanıcı adı
//	ürün adı
//	ürün detayı
//	miktarı
//	önceliği(kısa süre/ orta süre/ uzun süre) (şimdilik yazılmadı)
