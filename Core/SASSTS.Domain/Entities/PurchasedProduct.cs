using SASSTS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Domain.Entities
{
    public class PurchasedProduct : AuditableEntity
    {
        public PurchasedProduct() 
        {
            Products = new List<Product>();
        }

        public int PurchaseRequestId { get; set; }
        public int PriceOfferId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int WholesalerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public string WholesalerName { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DeliveryDate { get; set; }

        public PurchaseRequest PurchaseRequest { get; set; }
        public PriceOffer PriceOffers { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Wholesaler Wholesaler { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
//satın alınan ürün
//	talep id
//	teklif id
//	alım onaylayan yetkili id
//	ürün id
//  tedarikçi id
//  kullanıcı adı
//	ürün adı
//  tedarikçi adı
//	ürün miktarı
//	firma adı
//	birim fiyat
//	toplam fiyat
//	sipariş teslim süresi