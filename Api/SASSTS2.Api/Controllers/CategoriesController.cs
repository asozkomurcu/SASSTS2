using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.CategoryDtos;
using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.RequestModels.CategoriesRM;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Services.Implementation;
using SASSTS2.Application.Validators.CategoryValidators;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;

namespace SASSTS2.Api.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<CustomerDto>>> GatAllCustomerById(int id)
        {
            var category = await _categoryService.GetCategoryById(new GetCategoryByIdVM { Id = id });
            return Ok(category);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCategory(CreateCategoryVM createCategoryVM)
        {
            var categoryId = await _categoryService.CreateCategory(createCategoryVM);
            return Ok(categoryId);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeleteCategory(DeleteCategoryVM deleteCategoryVM)
        {
            var categoryId = await _categoryService.DeleteCategory(deleteCategoryVM);
            return Ok(categoryId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateCategory(int id, UpdateCategoryVM updateCategoryVM)
        {
            if (id != updateCategoryVM.Id)
            {
                return BadRequest();
            }

            var categoryId = await _categoryService.UpdateCategory(updateCategoryVM);
            return Ok(categoryId);
        }
    }
}
