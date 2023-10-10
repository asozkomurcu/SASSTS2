using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Application.Behaviors;
using SASSTS2.Application.Exceptions;
using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.RequestModels.CustomersRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Validators.BillValidators;
using SASSTS2.Application.Validators.CustomerValidators;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;
using SASSTS2.Domain.UWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CustomerService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<CustomerDto>>> GetAllCustomers()
        {
            var result = new Result<List<CustomerDto>>();
            
            var customerEntities = await _unitWork.GetRepository<Customer>().GetAllAsync();
            var customerDtos = await customerEntities.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = customerDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetCustomerByIdValidator))]
        public async Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdVM getCustomerByIdVM)
        {
            var result = new Result<CustomerDto>();

            var customerExists = await _unitWork.GetRepository<Customer>().AnyAsync(x=>x.Id == getCustomerByIdVM.Id);
            if (!customerExists) 
            {
                throw new NotFoundException($"{getCustomerByIdVM.Id} numaralı personel bulunamadı.");
            }

            var customerEntity = await _unitWork.GetRepository<Customer>().GetById(getCustomerByIdVM.Id);

            var customerDto = _mapper.Map<Customer, CustomerDto>(customerEntity);

            result.Data = customerDto;
            _unitWork.Dispose();
            return result;
        }

        //[ValidationBehavior(typeof(CreateCustomerValidator))]
        //public async Task<Result<int>> CreateCustomer(CreateCustomerVM createCustomerVM)
        //{
        //    var result = new Result<int>();

        //    var customerExistsSameName = await _unitWork.GetRepository<Customer>().AnyAsync(x=>x.IdentityNumber==createCustomerVM.IdentityNumber);
        //    if (customerExistsSameName)
        //    {
        //        throw new AlreadyExistsException($"{createCustomerVM.IdentityNumber} TC kimlik numaralı personel kayıtlarda mevcut.");
        //    }

        //    var customerEntity = _mapper.Map<CreateCustomerVM, Customer>(createCustomerVM);

        //    _unitWork.GetRepository<Customer>().Add(customerEntity);
        //    await _unitWork.CommitAsync();

        //    result.Data = customerEntity.Id;
        //    _unitWork.Dispose();
        //    return result;
        //}

        [ValidationBehavior(typeof(DeleteCustomerValidator))]
        public async Task<Result<int>> DeleteCustomer(DeleteCustomerVM deleteCustomerVM)
        {
            var result = new Result<int>();

            var customerExists = await _unitWork.GetRepository<Customer>().AnyAsync(x=>x.Id == deleteCustomerVM.Id);
            if (!customerExists)
            {
                throw new NotFoundException($"{deleteCustomerVM.Id} numaralı personel bulunamadı.");
            }

            _unitWork.GetRepository<Customer>().Delete(deleteCustomerVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deleteCustomerVM.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateCustomerValidator))]
        public async Task<Result<int>> UpdateCustomer(UpdateCustomerVM updateCustomerVM)
        {
            var result = new Result<int>();

            var customerExists = await _unitWork.GetRepository<Customer>().GetById(updateCustomerVM.Id);
            if (customerExists is null)
            {
                throw new NotFoundException($"{updateCustomerVM.Id} numaralı personel bulunamadı.");
            }

            var updateCustomer = _mapper.Map(updateCustomerVM, customerExists);
            _unitWork.GetRepository<Customer>().Update(updateCustomer);
            await _unitWork.CommitAsync();

            result.Data = updateCustomerVM.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
