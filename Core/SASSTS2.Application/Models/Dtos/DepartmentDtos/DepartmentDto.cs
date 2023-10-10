using SASSTS2.Application.Models.Dtos.CompanyDtos;
using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Models.Dtos.DepartmentDtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string DepartmentName { get; set; }
        public string CompanyName { get; set; }

        public CompanyDto Company { get; set; }

        public static implicit operator DepartmentDto(List<CustomerDto> v)
        {
            throw new NotImplementedException();
        }
    }
}
