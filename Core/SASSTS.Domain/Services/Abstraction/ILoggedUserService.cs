using SASSTS2.Domain.Entities;

namespace SASSTS2.Domain.Services.Abstraction
{
    public interface ILoggedUserService
    {
        int? CustomerId { get; }
        string CustomerName { get; }
        string CustomerSurname { get; }
        string Email { get; }
        Roles? Role { get; }
    }
}
