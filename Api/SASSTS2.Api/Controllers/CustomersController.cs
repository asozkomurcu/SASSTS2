using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.CompanyDtos;
using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.RequestModels.CompaniesRM;
using SASSTS2.Application.Models.RequestModels.CustomersRM;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Services.Implementation;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;

namespace SASSTS2.Api.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<CustomerDto>>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(new GetCustomerByIdVM { Id = id });
            return Ok(customer);
        }

        //[HttpPost("create")]
        //public async Task<ActionResult<Result<int>>> CreateCustomer(CreateCustomerVM createCustomerVM)
        //{
        //    var customerId = await _customerService.CreateCustomer(createCustomerVM);
        //    return Ok(customerId);
        //}

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeleteCustomer(DeleteCustomerVM deleteCustomerVM)
        {
            var customerId = await _customerService.DeleteCustomer(deleteCustomerVM);
            return Ok(customerId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateCustomer(int id, UpdateCustomerVM updateCustomerVM)
        {
            if (id != updateCustomerVM.Id)
            {
                return BadRequest();
            }

            var customerId = await _customerService.UpdateCustomer(updateCustomerVM);
            return Ok(customerId);
        }
    }
}
