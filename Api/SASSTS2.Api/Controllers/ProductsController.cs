using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.ProductDtos;
using SASSTS2.Application.Models.RequestModels.ProductsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Api.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<ProductDto>>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(new GetProductByIdVM { Id = id });
            return Ok(product);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateProduct(CreateProductVM createProductVM)
        {
            var productId = await _productService.CreateProduct(createProductVM);
            return Ok(productId);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeleteProduct(DeleteProductVM deleteProductVM)
        {
            var productId = await _productService.DeleteProduct(deleteProductVM);
            return Ok(productId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateProduct(int id, UpdateProductVM updateProductVM)
        {
            if (id != updateProductVM.Id)
            {
                return BadRequest();
            }

            var productId = await _productService.UpdateProduct(updateProductVM);
            return Ok(productId);
        }
    }
}
