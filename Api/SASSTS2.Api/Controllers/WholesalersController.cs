using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.WholesalerDtos;
using SASSTS2.Application.Models.RequestModels.WholesalersRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Api.Controllers
{
    [Route("wholesaler")]
    [ApiController]
    public class WholesalersController : ControllerBase
    {
        private readonly IWholesalerService _wholesalerService;

        public WholesalersController(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<WholesalerDto>>> GetAllWholesalers()
        {
            var wholesalers = await _wholesalerService.GetAllWholesaler();
            return Ok(wholesalers);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<WholesalerDto>>> GetWholesalerById(int id)
        {
            var wholesaler = await _wholesalerService.GetWholesalerById(new GetWholesalerByIdVM { Id = id });
            return Ok(wholesaler);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateWholesaler(CreateWholesalerVM createWholesalerVM)
        {
            var wholesalerId = await _wholesalerService.CreateWholesaler(createWholesalerVM);
            return Ok(wholesalerId);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeleteWholesaler(DeleteWholesalerVM deleteWholesalerVM)
        {
            var wholesalerId = await _wholesalerService.DeleteWholesaler(deleteWholesalerVM);
            return Ok(wholesalerId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateWholesaler(int id, UpdateWholesalerVM updateWholesalerVM)
        {
            if (id != updateWholesalerVM.Id)
            {
                return BadRequest();
            }

            var wholesalerId = await _wholesalerService.UpdateWholesaler(updateWholesalerVM);
            return Ok(wholesalerId);
        }
    }
}
