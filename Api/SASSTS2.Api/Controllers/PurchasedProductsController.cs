using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.PurchasedProductDtos;
using SASSTS2.Application.Models.RequestModels.PurchasedProductsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Api.Controllers
{
    [Route("purchasedProduct")]
    [ApiController]
    public class PurchasedProductsController : ControllerBase
    {
        private readonly IPurchasedProductService _purchasedProductService;

        public PurchasedProductsController(IPurchasedProductService purchasedProductService)
        {
            _purchasedProductService = purchasedProductService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<PurchasedProductDto>>> GetAllPurchasedProduct()
        {
            var purchasedProducts = await _purchasedProductService.GetAllPurchasedProduct();
            return Ok(purchasedProducts);
        }

        [HttpGet("get/id:int")]
        public async Task<ActionResult<Result<PurchasedProductDto>>> GetPurchasedProductById(int id)
        {
            var purchasedProduct = await _purchasedProductService.GetPurchasedProductById(new GetPurchasedProductByIdVM { Id = id });
            return Ok(purchasedProduct);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreatePurchasedProduct(CreatePurchasedProductVM createpurchasedProductVM)
        {
            var purchasedProductId = await _purchasedProductService.CreatePurchasedProduct(createpurchasedProductVM);
            return Ok(purchasedProductId);
        }

        [HttpPost("update")]
        public async Task<ActionResult<Result<int>>> UpdatePurchasedProduct(UpdatePurchasedProductVM updatepurchasedProductVM)
        {
            var purchasedProductId = await _purchasedProductService.UpdatePurchasedProduct(updatepurchasedProductVM);
            return Ok(purchasedProductId);
        }
    }
}
