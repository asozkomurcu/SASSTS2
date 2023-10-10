using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SASSTS2.Application.Behaviors;
using SASSTS2.Application.Exceptions;
using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.Dtos.DepartmentDtos;
using SASSTS2.Application.Models.RequestModels.DepartmentsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Validators.DepartmentValidators;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;
using SASSTS2.Domain.UWork;

namespace SASSTS2.Application.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _unitWork;

        public DepartmentService(IMapper mapper, IUnitWork unitWork)
        {
            _mapper = mapper;
            _unitWork = unitWork;
        }

        public async Task<Result<List<DepartmentDto>>> GetAllDepartments()
        {
            var result = new Result<List<DepartmentDto>>();

            var departmentEntities = await _unitWork.GetRepository<Department>().GetAllAsync();
            var departmentDtos = await departmentEntities.ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = departmentDtos;
            _unitWork.Dispose();
            return result;

        }

        [ValidationBehavior(typeof(GetDepartmentByIdValidator))]
        public async Task<Result<DepartmentDto>> GetDepartmentById(GetDepartmentByIdVM getDepartmentByIdVM)
        {
            var result = new Result<DepartmentDto>();

            var departmentExists = await _unitWork.GetRepository<Department>().AnyAsync(x=>x.Id == getDepartmentByIdVM.Id);
            if (!departmentExists)
            {
                throw new NotFoundException($"{getDepartmentByIdVM.Id} numaralı depatman bulunamadı.");
            }

            var departmentEntity = await _unitWork.GetRepository<Department>().GetById(getDepartmentByIdVM.Id);

            var departmentDto = _mapper.Map<Department, DepartmentDto>(departmentEntity);

            result.Data = departmentDto;
            _unitWork.Dispose();
            return result;
        }

        

        [ValidationBehavior(typeof(CreateDepartmentValidator))]
        public async Task<Result<int>> CreateDepartment(CreateDepartmentVM createDepartmentVM)
        {
            var result = new Result<int>();

            var departmentExistsSameName = await _unitWork.GetRepository<Department>().AnyAsync(x => x.DepartmentName == createDepartmentVM.DepartmentName);
            if (departmentExistsSameName)
            {
                throw new AlreadyExistsException($"{createDepartmentVM.DepartmentName} isminde bir departman zaten mevcut.");
            }

            var companyExistsSame = await _unitWork.GetRepository<Company>().AnyAsync(x => x.CompanyName == createDepartmentVM.CompanyName && x.Id==createDepartmentVM.CompanyId);
            if (!companyExistsSame)
            {
                throw new NotFoundException($"Girilen şirket bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var departmentEntity = _mapper.Map<CreateDepartmentVM, Department>(createDepartmentVM);

            _unitWork.GetRepository<Department>().Add(departmentEntity);
            await _unitWork.CommitAsync();

            result.Data = departmentEntity.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(DeleteDepartmentValidator))]
        public async Task<Result<int>> DeleteDepartment(DeleteDepartmentVM deleteDepartmentVM)
        {
            var result = new Result<int>();

            var departmentExists = await _unitWork.GetRepository<Department>().AnyAsync(x => x.Id == deleteDepartmentVM.Id);
            if (!departmentExists)
            {
                throw new NotFoundException($"{deleteDepartmentVM.Id} numaralı departman bulunamadı.");
            }

            _unitWork.GetRepository<Department>().Delete(deleteDepartmentVM.Id);
            await _unitWork.CommitAsync();

            result.Data = deleteDepartmentVM.Id;
            _unitWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateDepartmentValidator))]
        public async Task<Result<int>> UpdateDepartment(UpdateDepartmentVM updateDepartmentVM)
        {
            var result = new Result<int>();

            var existsDepartment = await _unitWork.GetRepository<Department>().GetById(updateDepartmentVM.Id);
            if (existsDepartment is null)
            {
                throw new NotFoundException($"{updateDepartmentVM} numaralı departman bulunamadı.");
            }

            var companyExistsSame = await _unitWork.GetRepository<Company>().AnyAsync(x => x.CompanyName == updateDepartmentVM.CompanyName && x.Id == updateDepartmentVM.CompanyId);
            if (!companyExistsSame)
            {
                throw new NotFoundException($"Girilen şirket bilgileri eşleşmiyor veya kayıtlı değil.");
            }

            var updatedDepartment = _mapper.Map(updateDepartmentVM, existsDepartment);

            _unitWork.GetRepository<Department>().Update(updatedDepartment);
            await _unitWork.CommitAsync();

            result.Data = updatedDepartment.Id;
            _unitWork.Dispose();
            return result;
        }
    }
}
