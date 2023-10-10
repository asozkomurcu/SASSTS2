using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.PriceOfferDtos;
using SASSTS2.Application.Models.RequestModels.PriceOffersRM;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Services.Implementation;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;

namespace SASSTS2.Api.Controllers
{
    [Route("priceOffers")]
    [ApiController]
    public class PriceOffersController : ControllerBase
    {
        private readonly IPriceOfferService _priceOfferService;

        public PriceOffersController(IPriceOfferService priceOfferService)
        {
            _priceOfferService = priceOfferService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<PriceOfferDto>>> GetAllPriceOffers()
        {
            var priceOffers = await _priceOfferService.GetAllPriceOffers();
            return Ok(priceOffers);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<PriceOfferDto>>> GetPriceOfferById(int id)
        {
            var priceOffer = await _priceOfferService.GetPriceOfferById(new GetPriceOfferByIdVM { Id = id });
            return Ok(priceOffer);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeletePriceOffer(DeletePriceOfferVM deletePriceOfferVM)
        {
            var PriceOfferId = await _priceOfferService.DeletePriceOffer(deletePriceOfferVM);
            return Ok(PriceOfferId);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreatePriceOffer(CreatePriceOfferVM createPriceOfferVM)
        {
            var priceOfferId = await _priceOfferService.CreatePriceOffer(createPriceOfferVM);
            return Ok(priceOfferId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdatePriceOffer(int id, UpdatePriceOfferVM updatePriceOfferVM)
        {
            if (id != updatePriceOfferVM.Id)
            {
                return BadRequest();
            }

            var priceOfferId = await _priceOfferService.UpdatePriceOffer(updatePriceOfferVM);
            return Ok(priceOfferId);
        }
    }
}
