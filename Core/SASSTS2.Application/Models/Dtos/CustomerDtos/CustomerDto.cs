using SASSTS2.Application.Models.Dtos.DepartmentDtos;
using SASSTS2.Domain.Entities;

namespace SASSTS2.Application.Models.Dtos.CustomerDtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public string DepartmentName { get; set; }
        public Roles Role { get; set; }

        public DepartmentDto Department { get; set; }

    }
}
