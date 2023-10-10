using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.Dtos.ProductRequestDtos;
using SASSTS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Models.Dtos.PurchaseRequestDtos
{
    public class PurchaseRequestDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Status Status { get; set; }

        public CustomerDto Customer { get; set; }
        //public ProductRequestDto ProductRequest { get; set; }

    }
}
