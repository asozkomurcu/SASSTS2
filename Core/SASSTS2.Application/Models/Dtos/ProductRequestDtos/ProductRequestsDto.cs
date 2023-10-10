using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.Dtos.ProductDtos;
using SASSTS2.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Models.Dtos.ProductRequestDtos
{
    public class ProductRequestDto
    {
        //public int Id { get; set; }
        public int PurchaseRequestId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Amount { get; set; }

        public PurchaseRequestDto PurchaseRequest { get; set; }
        public ProductDto Product { get; set; }
        public CustomerDto Customer { get; set; }

    }
}
