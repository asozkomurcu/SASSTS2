using SASSTS2.Application.Models.Dtos.BillsDtos;
using SASSTS2.Application.Models.RequestModels.BillsRM;
using SASSTS2.Application.Models.RequestModels.BilslRM;
using SASSTS2.Application.Validators.BillValidators;
using SASSTS2.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface IBillService
    {
        Task<Result<List<BillDto>>> GetAllBills();
        Task<Result<BillDto>> GetBillById(GetBillByIdVM getBillByIdVM);

        Task<Result<int>> CreateBill(CreateBillVM createBillVM);
        Task<Result<int>> UpdateBill(UpdateBillVM updateBillVM);
    }
}
