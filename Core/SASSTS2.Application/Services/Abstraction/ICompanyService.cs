using SASSTS2.Application.Models.Dtos.CompanyDtos;
using SASSTS2.Application.Models.RequestModels.CompaniesRM;
using SASSTS2.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface ICompanyService
    {
        Task<Result<List<CompanyDto>>> GetAllCompanies();
        Task<Result<CompanyDto>> GetCompanyById(GetCompanyByIdVM getCompanyByIdVM);
        Task<Result<int>> CreateCompany(CreateCompanyVM createCompanyVM);
        Task<Result<int>> UpdateCompany(UpdateCompanyVM updateCompanyVM);
        Task<Result<int>> DeleteCompany(DeleteCompanyVM deleteCompanyVM);
    }
}
