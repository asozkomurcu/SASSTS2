﻿using FluentValidation;
using SASSTS2.Application.Models.RequestModels.DepartmentsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.DepartmentValidators
{
    public class GetDepartmentByIdValidator : AbstractValidator<GetDepartmentByIdVM>
    {
        public GetDepartmentByIdValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Departman kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Departman kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
