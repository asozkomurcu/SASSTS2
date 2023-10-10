using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Application.Behaviors;
using SASSTS2.Application.Exceptions;
using SASSTS2.Application.Models.Dtos.CompanyDtos;
using SASSTS2.Application.Models.RequestModels.CompaniesRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Validators.CompanyValidators;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;
using SASSTS2.Domain.UWork;

namespace SASSTS2.Application.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public CompanyService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<CompanyDto>>> GetAllCompanies()
        {
            var result = new Result<List<CompanyDto>>();

            var companyEntites = await _unitWork.GetRepository<Company>().GetAllAsync();
            var companyDtos = await companyEntites.ProjectTo<CompanyDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = companyDtos;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetCompanyByIdValidator))]
        public async Task<Result<CompanyDto>> GetCompanyById(GetCompanyByIdVM getCompanyByIdVM)
        {
            var result = new Result<CompanyDto>();

            var companyExists = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Id == getCompanyByIdVM.Id);
            if (!companyExists)
            {
                throw new NotFoundException($"{getCompanyByIdVM.Id} numaralı şirket bulunamadı.");
            }

            var companyEntity = await _unitWork.GetRepository<Company>().GetById(getCompanyByIdVM.Id);

            var companyDto = _mapper.Map<Company, CompanyDto>(companyEntity);

            result.Data = companyDto;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(CreateCompanyValidator))]
        public async Task<Result<int>> CreateCompany(CreateCompanyVM createCompanyVM)
        {
            var result = new Result<int>();

            var companyExistsSameName = await _unitWork.GetRepository<Company>().AnyAsync(x => x.CompanyName == createCompanyVM.CompanyName);
            if (companyExistsSameName)
            {
                throw new AlreadyExistsException($"{createCompanyVM.CompanyName} isminde bir şirket zaten mevcut.");
            }

            var companyEntity = _mapper.Map<CreateCompanyVM, Company>(createCompanyVM);

            _unitWork.GetRepository<Company>().Add(companyEntity);
            await _unitWork.CommitAsync();

            result.Data = companyEntity.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeleteCompanyValidator))]
        public async Task<Result<int>> DeleteCompany(DeleteCompanyVM deleteCompanyVM)
        {
            var result = new Result<int>();

            var companyExists = await _unitWork.GetRepository<Company>().AnyAsync(x => x.Id == deleteCompanyVM.Id);
            if (!companyExists)
            {
                throw new NotFoundException($"{deleteCompanyVM.Id} numaralı şirket bulunamadı.");
            }

            _unitWork.GetRepository<Company>().Delete(deleteCompanyVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deleteCompanyVM.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateCompanyValidator))]
        public async Task<Result<int>> UpdateCompany(UpdateCompanyVM updateCompanyVM)
        {
            var result = new Result<int>();

            var existsCompany = await _unitWork.GetRepository<Company>().GetById(updateCompanyVM.Id);
            if (existsCompany is null)
            {
                throw new NotFoundException($"{updateCompanyVM} numaralı şirket bulunamadı.");
            }


            var updatedCompany = _mapper.Map(updateCompanyVM, existsCompany);

            _unitWork.GetRepository<Company>().Update(updatedCompany);
            await _unitWork.CommitAsync();

            result.Data = updatedCompany.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
