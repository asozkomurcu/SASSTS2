using SASSTS2.Application.Models.Dtos.TokenDtos;
using SASSTS2.Application.Models.RequestModels.AccountsRM;
using SASSTS2.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface IAccountService
    {
        Task<Result<bool>> Register(RegisterVM createUserVM);
        Task<Result<TokenDto>> Login(LoginVM loginVM);

        Task<Result<bool>> UpdateUser(UpdateUserVM updateUserVM);
    }
}
