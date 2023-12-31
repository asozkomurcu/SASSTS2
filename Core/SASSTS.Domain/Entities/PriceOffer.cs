﻿using SASSTS2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Domain.Entities
{
    public class PriceOffer : DeletetableEntity
    {
        public PriceOffer() 
        {
            Products = new List<Product>();
        }
        public int PurchaseRequestId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int WholesalerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string WholesalerName { get; set; }
        public decimal Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryDate { get; set; }

        public PurchaseRequest PurchaseRequest { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Wholesaler Wholesaler { get; set; }

        public ICollection<PurchasedProduct> PurchasedProducts { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
//satın alınacak ürün için toplanan fiyat teklifleri
//	teklif id
//	talep id
//	teklif alan kullanıcı id
//	ürün id
//  tedarikçi id
//	teklif alan kullanıcı ad
//	ürün adı
//  tedarikçi adı
//	ürün miktarı
//	birim fiyat
//	toplam fiyat
//	sipariş teslim süresi