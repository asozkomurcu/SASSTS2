using SASSTS2.Application.Models.Dtos.ProductRequestDtos;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using SASSTS2.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface IProductRequestService
    {
        Task<Result<List<ProductRequestDto>>> GetAllProductRequsets();
        Task<Result<ProductRequestDto>> GetProductRequestById(GetProductRequestByIdVM getProductRequestByIdVM);
        Task<Result<int>> CreateProductRequest(CreateProductRequestVM createProductRequestVM);
        Task<Result<int>> UpdateProductRequest(UpdateProductRequestVM updateProductRequestVM);
        Task<Result<int>> DeleteProductRequest(DeleteProductRequestVM deleteProductRequestVM);
    }
}
