﻿using FluentValidation;
using SASSTS2.Application.Models.RequestModels.WholesalersRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.WholesalerValidators
{
    public class GetWholesalerByIdValidator : AbstractValidator<GetWholesalerByIdVM>
    {
        public GetWholesalerByIdValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Tedarikçi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Tedarikçi kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
