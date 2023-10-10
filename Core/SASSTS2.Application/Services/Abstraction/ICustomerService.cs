using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.RequestModels.CustomersRM;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface ICustomerService
    {
        Task<Result<List<CustomerDto>>> GetAllCustomers();
        Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdVM getCustomerByIdVM);
        //Task<Result<int>> CreateCustomer(CreateCustomerVM createCustomerVM);
        Task<Result<int>> UpdateCustomer(UpdateCustomerVM updateCustomerVM);
        Task<Result<int>> DeleteCustomer(DeleteCustomerVM deleteCustomerVM);
    }
}
