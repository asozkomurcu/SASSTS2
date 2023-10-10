using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SASSTS2.Application.Models.Dtos.CustomerDtos;
using SASSTS2.Application.Models.Dtos.DepartmentDtos;
using SASSTS2.Application.Models.RequestModels.CustomersRM;
using SASSTS2.Application.Models.RequestModels.DepartmentsRM;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using SASSTS2.Application.Services.Abstraction;
using SASSTS2.Application.Services.Implementation;
using SASSTS2.Application.Wrapper;
using SASSTS2.Domain.Entities;

namespace SASSTS2.Api.Controllers
{
    [Route("department")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<DepartmentDto>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<DepartmentDto>>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentById(new GetDepartmentByIdVM { Id = id });
            return Ok(department);
        }

        

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateDepartment(CreateDepartmentVM createDepartmentVM)
        {
            var departmentId = await _departmentService.CreateDepartment(createDepartmentVM);
            return Ok(departmentId);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Result<int>>> DeleteDepartment(DeleteDepartmentVM deleteDepartmentVM)
        {
            var departmentId = await _departmentService.DeleteDepartment(deleteDepartmentVM);
            return Ok(departmentId);
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<Result<int>>> UpdateDepartment(int id, UpdateDepartmentVM updateDepartmentVM)
        {
            if (id != updateDepartmentVM.Id)
            {
                return BadRequest();
            }

            var departmentId = await _departmentService.UpdateDepartment(updateDepartmentVM);
            return Ok(departmentId);
        }
    }
}
