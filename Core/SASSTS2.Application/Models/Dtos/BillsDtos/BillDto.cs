﻿using SASSTS2.Application.Models.Dtos.ProductDtos;
using SASSTS2.Application.Models.Dtos.WholesalerDtos;
using SASSTS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Models.Dtos.BillsDtos
{
    public class BillDto
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public int ProductId { get; set; }
        public DateTime BillDate { get; set; }
        public string BillNumber { get; set; }
        public string BillType { get; set; }
        public string WholesalerName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int KDV { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalKDV { get; set; }
        public decimal TotalPrice { get; set; }

        public WholesalerDto Wholesaler { get; set; }
        public ProductDto Product { get; set; }
    }
}
