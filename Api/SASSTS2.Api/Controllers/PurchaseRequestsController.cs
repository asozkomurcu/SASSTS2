using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.ProductDtos;
using SASSTS2.Application.Models.Dtos.PurchaseRequestDtos;
using SASSTS2.Application.Models.RequestModels.PurchaseRequestsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Api.Controllers
{
    [Route("purchaseRequest")]
    [ApiController]
    public class PurchaseRequestsController : ControllerBase
    {
        private readonly IPurchaseRequestService _purchaseRequestService;

        public PurchaseRequestsController(IPurchaseRequestService purchaseRequestService)
        {
            _purchaseRequestService = purchaseRequestService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<PurchaseRequestDto>>> GetAllPurchaseRequests()
        {
            var purchaseRequests = await _purchaseRequestService.GetAllPurchaseRequests();
            return Ok(purchaseRequests);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<ProductDto>>> GetProductById(int id)
        {
            var purchaseRequest = await _purchaseRequestService.GetPurchaseRequestById(new GetPurchaseRequestByIdVM { Id = id });
            return Ok(purchaseRequest);
        }

        //[HttpPost("create")]
        //public async Task<ActionResult<Result<int>>> CreatePurchaseRequest(CreatePurchaseRequestVM createPurchaseRequestVM)
        //{
        //    var purchaseRequestId = await _purchaseRequestService.CreatePurchaseRequest(createPurchaseRequestVM);
        //    return Ok(purchaseRequestId);
        //}

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeletePurchaseRequest(DeletePurchaseRequestVM deletePurchaseRequestVM)
        {
            var purchaseRequestId = await _purchaseRequestService.DeletePurchaseRequest(deletePurchaseRequestVM);
            return Ok(purchaseRequestId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdatePurchaseRequest(int id, UpdatePurchaseRequestVM updatePurchaseRequestVM)
        {
            if (id != updatePurchaseRequestVM.Id)
            {
                return BadRequest();
            }

            var purchaseRequestId = await _purchaseRequestService.UpdatePurchaseRequest(updatePurchaseRequestVM);
            return Ok(purchaseRequestId);
        }
    }
}
