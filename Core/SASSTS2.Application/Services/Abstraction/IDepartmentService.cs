﻿using SASSTS2.Application.Models.Dtos.DepartmentDtos;
using SASSTS2.Application.Models.RequestModels.DepartmentsRM;
using SASSTS2.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Services.Abstraction
{
    public interface IDepartmentService
    {
        Task<Result<List<DepartmentDto>>> GetAllDepartments();
        Task<Result<DepartmentDto>> GetDepartmentById(GetDepartmentByIdVM getDepartmentByIdVM);
        Task<Result<int>> CreateDepartment(CreateDepartmentVM createDepartmentVM);
        Task<Result<int>> UpdateDepartment(UpdateDepartmentVM updateDepartmentVM);
        Task<Result<int>> DeleteDepartment(DeleteDepartmentVM deleteDepartmentVM);
    }
}
