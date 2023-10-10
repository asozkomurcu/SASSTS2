using SASSTS2.Application.Models.Dtos.CategoryDtos;
using SASSTS2.Application.Models.RequestModels.CategoriesRM;
using SASSTS2.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<Result<List<CategoryDto>>> GetAllCategories();
        Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdVM getCategoryByIdVM);
        Task<Result<int>> CreateCategory(CreateCategoryVM createCategoryVM);
        Task<Result<int>> UpdateCategory(UpdateCategoryVM updateCategoryVM);
        Task<Result<int>> DeleteCategory(DeleteCategoryVM deleteCategoryVM);
    }
}
