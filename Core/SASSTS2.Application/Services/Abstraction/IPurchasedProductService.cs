﻿using SASSTS2.Application.Models.Dtos.PurchasedProductDtos;
using SASSTS2.Application.Models.RequestModels.PurchasedProductsRM;
using SASSTS2.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface IPurchasedProductService
    {
        Task<Result<List<PurchasedProductDto>>> GetAllPurchasedProduct();
        Task<Result<PurchasedProductDto>> GetPurchasedProductById(GetPurchasedProductByIdVM getPurchasedProductByIdVM);
        Task<Result<int>> CreatePurchasedProduct(CreatePurchasedProductVM createPurchasedProductVM);
        Task<Result<int>> UpdatePurchasedProduct(UpdatePurchasedProductVM updatePurchasedProductVM);
    }
}
