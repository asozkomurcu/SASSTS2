using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Models.Dtos.AccountDtos
{
    public class AccountDto
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? LastUserIp { get; set; }

        public CustomerDto Customer { get; set; }
    }
}
