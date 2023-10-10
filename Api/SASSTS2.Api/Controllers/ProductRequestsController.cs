using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.ProductRequestDtos;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using SASSTS2.Application.Models.RequestModels.ProductsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Services.Implementation;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Api.Controllers
{
    [Route("productRequest")]
    [ApiController]
    public class ProductRequestsController : ControllerBase
    {
        private readonly IProductRequestService _productRequestService;

        public ProductRequestsController(IProductRequestService productRequestService)
        {
            _productRequestService = productRequestService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<ProductRequestDto>>> GetAllProductRequest()
        {
            var productRequests = await _productRequestService.GetAllProductRequsets();
            return Ok(productRequests);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<ProductRequestDto>>> GetProductRequestById(int id)
        {
            var productRequest = await _productRequestService.GetProductRequestById(new GetProductRequestByIdVM { Id = id });
            return Ok(productRequest);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateProductRequest(CreateProductRequestVM createProductRequestVM)
        {
            var productRequestId = await _productRequestService.CreateProductRequest(createProductRequestVM);
            return Ok(productRequestId);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeleteProductRequest(DeleteProductRequestVM deleteProductRequestVM)
        {
            var productRequestId = await _productRequestService.DeleteProductRequest(deleteProductRequestVM);
            return Ok(productRequestId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateProductRequest(int id, UpdateProductRequestVM updateProductRequestVM)
        {
            if (id != updateProductRequestVM.Id)
            {
                return BadRequest();
            }

            var productRequestId = await _productRequestService.UpdateProductRequest(updateProductRequestVM);
            return Ok(productRequestId);
        }
    }
}
