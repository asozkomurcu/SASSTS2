using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.BillsDtos;
using SASSTS2.Application.Models.Dtos.CompanyDtos;
using SASSTS2.Application.Models.RequestModels.BillsRM;
using SASSTS2.Application.Models.RequestModels.BilslRM;
using SASSTS2.Application.Models.RequestModels.CompaniesRM;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Services.Implementation;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;

namespace SASSTS2.Api.Controllers
{
    [Route("company")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<CompanyDto>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<CompanyDto>>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(new GetCompanyByIdVM { Id = id });
            return Ok(company);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateCompany(CreateCompanyVM createCompanyVM)
        {
            var companyId = await _companyService.CreateCompany(createCompanyVM);
            return Ok(companyId);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeleteCompany(DeleteCompanyVM deleteCompanyVM)
        {
            var companyId = await _companyService.DeleteCompany( deleteCompanyVM);
            return Ok(companyId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateCompany(int id, UpdateCompanyVM updateCompanyVM)
        {
            if (id != updateCompanyVM.Id)
            {
                return BadRequest();
            }

            var companyId = await _companyService.UpdateCompany(updateCompanyVM);
            return Ok(companyId);
        }
    }
}
