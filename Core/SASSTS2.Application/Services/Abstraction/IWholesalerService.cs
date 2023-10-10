using SASSTS2.Application.Models.Dtos.WholesalerDtos;
using SASSTS2.Application.Models.RequestModels.WholesalersRM;
using SASSTS2.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface IWholesalerService
    {
        Task<Result<List<WholesalerDto>>> GetAllWholesaler();
        Task<Result<WholesalerDto>> GetWholesalerById(GetWholesalerByIdVM getWholesalerByIdVM);
        Task<Result<int>> CreateWholesaler(CreateWholesalerVM createWholesalerVM);
        Task<Result<int>> UpdateWholesaler(UpdateWholesalerVM updateWholesalerVM);
        Task<Result<int>> DeleteWholesaler(DeleteWholesalerVM deleteWholesalerVM);
    }
}
