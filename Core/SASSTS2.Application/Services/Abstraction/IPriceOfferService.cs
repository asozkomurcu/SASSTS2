using SASSTS2.Application.Models.Dtos.PriceOfferDtos;
using SASSTS2.Application.Models.RequestModels.PriceOffersRM;
using SASSTS2.Application.Wrapper;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface IPriceOfferService
    {
        Task<Result<List<PriceOfferDto>>> GetAllPriceOffers();
        Task<Result<PriceOfferDto>> GetPriceOfferById(GetPriceOfferByIdVM getPriceOfferByIdVM);
        Task<Result<int>> CreatePriceOffer(CreatePriceOfferVM createPriceOfferVM);
        Task<Result<int>> UpdatePriceOffer(UpdatePriceOfferVM updatePriceOfferVM);
        Task<Result<int>> DeletePriceOffer(DeletePriceOfferVM deletePriceOfferVM);
    }
}
