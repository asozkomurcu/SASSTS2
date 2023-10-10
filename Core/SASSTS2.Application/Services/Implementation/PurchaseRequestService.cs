using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Application.Behaviors;
using SASSTS2.Application.Exceptions;
using SASSTS2.Application.Models.Dtos.ProductDtos;
using SASSTS2.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS2.Application.Models.RequestModels.PriceOffersRM;
using SASSTS2.Application.Models.RequestModels.ProductsRM;
using SASSTS2.Application.Models.RequestModels.PurchaseRequestsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Validators.BillValidators;
using SASSTS2.Application.Validators.PurchaseRequestValidators;
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
    public class PurchaseRequestService : IPurchaseRequestService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public PurchaseRequestService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }


        public async Task<Result<List<PurchaseRequestDto>>> GetAllPurchaseRequests()
        {
            var result = new Result<List<PurchaseRequestDto>>();

            var purchaseRequestEntites = await _unitWork.GetRepository<PurchaseRequest>().GetAllAsync();
            var purchaseRequestDtos = await purchaseRequestEntites.ProjectTo<PurchaseRequestDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = purchaseRequestDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetPurchaseRequestByIdValidator))]
        public async Task<Result<PurchaseRequestDto>> GetPurchaseRequestById(GetPurchaseRequestByIdVM getPurchaseRequestByIdVM)
        {
            var result = new Result<PurchaseRequestDto>();

            var purchaseRequestExists = await _unitWork.GetRepository<PurchaseRequest>().AnyAsync(x => x.Id == getPurchaseRequestByIdVM.Id);
            if (!purchaseRequestExists)
            {
                throw new NotFoundException($"{getPurchaseRequestByIdVM.Id} numaralı ürün bulunamadı.");
            }

            var purchaseRequestEntity = await _unitWork.GetRepository<PurchaseRequest>().GetById(getPurchaseRequestByIdVM.Id);

            var purchaseRequestDto = _mapper.Map<PurchaseRequest, PurchaseRequestDto>(purchaseRequestEntity);

            result.Data = purchaseRequestDto;
            _unitWork.Dispose();
            return result;
        }

        //[ValidationBehavior(typeof(CreatePurchaseRequestValidator))]
        //public async Task<Result<int>> CreatePurchaseRequest(CreatePurchaseRequestVM createPurchaseRequestVM)
        //{
        //    var result = new Result<int>();

        //    var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == createPurchaseRequestVM.CustomerName && x.Id == createPurchaseRequestVM.CustomerId);
        //    if (!customerExistsSame)
        //    {
        //        throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
        //    }


        //    var purchaseRequestEntity = _mapper.Map<CreatePurchaseRequestVM, PurchaseRequest>(createPurchaseRequestVM);

        //    _unitWork.GetRepository<PurchaseRequest>().Add(purchaseRequestEntity);
        //    await _unitWork.CommitAsync();

        //    result.Data = purchaseRequestEntity.Id;
        //    _unitWork.Dispose();
        //    return result;
        //}

        [ValidationBehavior(typeof(DeletePurchaseRequestValidator))]
        public async Task<Result<int>> DeletePurchaseRequest(DeletePurchaseRequestVM deletePurchaseRequestVM)
        {
            var result = new Result<int>();

            var purchaseRequestExists = await _unitWork.GetRepository<PurchaseRequest>().AnyAsync(x => x.Id == deletePurchaseRequestVM.Id);
            if (!purchaseRequestExists)
            {
                throw new NotFoundException($"{deletePurchaseRequestVM.Id} numaralı Satın alım talebi bulunamadı.");
            }

            _unitWork.GetRepository<PurchaseRequest>().Delete(deletePurchaseRequestVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deletePurchaseRequestVM.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdatePurchaseRequestValidator))]
        public async Task<Result<int>> UpdatePurchaseRequest(UpdatePurchaseRequestVM updatePurchaseRequestVM)
        {
            var result = new Result<int>();

            var existsPurchaseRequest = await _unitWork.GetRepository<PurchaseRequest>().GetById(updatePurchaseRequestVM.Id);
            if (existsPurchaseRequest is null)
            {
                throw new NotFoundException($"{updatePurchaseRequestVM} numaralı satın alım talebi bulunamadı.");
            }

            var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == updatePurchaseRequestVM.CustomerName && x.Id == updatePurchaseRequestVM.CustomerId);
            if (!customerExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }


            var updatedPurchaseRequest = _mapper.Map(updatePurchaseRequestVM, existsPurchaseRequest);

            _unitWork.GetRepository<PurchaseRequest>().Update(updatedPurchaseRequest);
            await _unitWork.CommitAsync();

            result.Data = updatedPurchaseRequest.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
