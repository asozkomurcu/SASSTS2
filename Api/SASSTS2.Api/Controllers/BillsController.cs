using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.BillsDtos;
using SASSTS2.Application.Models.RequestModels.BillsRM;
using SASSTS2.Application.Models.RequestModels.BilslRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Api.Controllers
{
    [Route("bill")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillsController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<BillDto>>> GetAllBills()
        {
            var bills = await _billService.GetAllBills();
            return Ok(bills);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<BillDto>>> GetBillById(int id)
        {
            var bill = await _billService.GetBillById(new GetBillByIdVM { Id = id });
            return Ok(bill);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateBill(CreateBillVM createBillVM)
        {
            var billId = await _billService.CreateBill(createBillVM);
            return Ok(billId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateBill(int id,UpdateBillVM updateBillVM)
        {
            if (id != updateBillVM.Id)
            {
                return BadRequest();
            }

            var billId = await _billService.UpdateBill(updateBillVM);
            return Ok(billId);
        }
    }
}
