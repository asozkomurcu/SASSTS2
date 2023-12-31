﻿using FluentValidation;
using SASSTS2.Application.Models.RequestModels.WholesalersRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.WholesalerValidators
{
    public class CreateWholesalerValidator : AbstractValidator<CreateWholesalerVM>
    {
        public CreateWholesalerValidator() 
        {
            RuleFor(x => x.WholesalerName)
                .NotEmpty().WithMessage("Tedarikçi adı boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Tedarikçi adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numaranızı giriniz.")
                .MinimumLength(11)
                .MaximumLength(11).WithMessage("Telefon numarası 11 hane olmalıdır.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Tedarikçi adres bilgisi boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Tedarikçi adres bilgisi en fazla 500 karakter olabilir.");
        }
    }
}