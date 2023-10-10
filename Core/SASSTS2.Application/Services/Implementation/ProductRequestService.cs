using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Application.Behaviors;
using SASSTS2.Application.Exceptions;
using SASSTS2.Application.Models.Dtos.CategoryDtos;
using SASSTS2.Application.Models.Dtos.ProductRequestDtos;
using SASSTS2.Application.Models.RequestModels.CategoriesRM;
using SASSTS2.Application.Models.RequestModels.PriceOffersRM;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Validators.BillValidators;
using SASSTS2.Application.Validators.ProductRequestValidators;
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
    public class ProductRequestService : IProductRequestService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public ProductRequestService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<ProductRequestDto>>> GetAllProductRequsets()
        {
            var result = new Result<List<ProductRequestDto>>();

            var productRequestEntites = await _unitWork.GetRepository<ProductRequest>().GetAllAsync();
            var productRequestDtos = await productRequestEntites.ProjectTo<ProductRequestDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = productRequestDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetProductRequestByIdValidator))]
        public async Task<Result<ProductRequestDto>> GetProductRequestById(GetProductRequestByIdVM getProductRequestByIdVM)
        {
            var result = new Result<ProductRequestDto>();

            var productRequestExists = await _unitWork.GetRepository<ProductRequest>().AnyAsync(x => x.Id == getProductRequestByIdVM.Id);
            if (!productRequestExists)
            {
                throw new NotFoundException($"{getProductRequestByIdVM.Id} numaralı satın alınacak ürün listesi bulunamadı.");
            }

            var productRequestEntity = await _unitWork.GetRepository<ProductRequest>().GetById(getProductRequestByIdVM.Id);

            var productRequestDto = _mapper.Map<ProductRequest, ProductRequestDto>(productRequestEntity);

            result.Data = productRequestDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreateProductRequestValidator))]
        public async Task<Result<int>> CreateProductRequest(CreateProductRequestVM createProductRequestVM)
        {
            var result = new Result<int>();

            var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == createProductRequestVM.CustomerName && x.Id == createProductRequestVM.CustomerId);
            if (!customerExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }


            var productExistsSame = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == createProductRequestVM.ProductName && x.Id == createProductRequestVM.ProductId);
            if (!productExistsSame)
            {
                throw new NotFoundException($"Girilen ürün bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var productRequestEntity = _mapper.Map<CreateProductRequestVM, ProductRequest>(createProductRequestVM);
            var purchaseRequestEntity = _mapper.Map<CreateProductRequestVM, PurchaseRequest>(createProductRequestVM);
            //var productRequestEntity = _mapper.Map<ProductRequest>(createProductRequestVM);
            //var purchaseRequestEntity = _mapper.Map<PurchaseRequest>(createProductRequestVM);

            _unitWork.GetRepository<ProductRequest>().Add(productRequestEntity);
            _unitWork.GetRepository<PurchaseRequest>().Add(purchaseRequestEntity);
            await _unitWork.CommitAsync();

            
            //result.Data = await _unitWork.CommitAsync();

            result.Data = productRequestEntity.Id;
            result.Data = purchaseRequestEntity.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeleteProductRequestValidator))]
        public async Task<Result<int>> DeleteProductRequest(DeleteProductRequestVM deleteProductRequestVM)
        {
            var result = new Result<int>();

            var productRequestExists = await _unitWork.GetRepository<ProductRequest>().AnyAsync(x => x.Id == deleteProductRequestVM.Id);
            if (!productRequestExists)
            {
                throw new NotFoundException($"{deleteProductRequestVM.Id} numaralı satın alınacak ürün listesi bulunamadı.");
            }

            _unitWork.GetRepository<ProductRequest>().Delete(deleteProductRequestVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deleteProductRequestVM.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateProductRequestValidator))]
        public async Task<Result<int>> UpdateProductRequest(UpdateProductRequestVM updateProductRequestVM)
        {
            var result = new Result<int>();

            var existsProductRequest = await _unitWork.GetRepository<ProductRequest>().GetById(updateProductRequestVM.Id);
            if (existsProductRequest is null)
            {
                throw new NotFoundException($"{updateProductRequestVM} numaralı satın alınacak ürün listesi bulunamadı.");
            }

            var customerExistsSame = await _unitWork.GetRepository<Customer>().AnyAsync(x => x.Name + ' ' + x.Surname == updateProductRequestVM.CustomerName && x.Id == updateProductRequestVM.CustomerId);
            if (!customerExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }


            var productExistsSame = await _unitWork.GetRepository<Product>().AnyAsync(x => x.ProductName == updateProductRequestVM.ProductName && x.Id == updateProductRequestVM.ProductId);
            if (!productExistsSame)
            {
                throw new NotFoundException($"Girilen personel bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var updatedProductRequest = _mapper.Map(updateProductRequestVM, existsProductRequest);

            _unitWork.GetRepository<ProductRequest>().Update(updatedProductRequest);
            await _unitWork.CommitAsync();

            result.Data = updatedProductRequest.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
