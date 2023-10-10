﻿using FluentValidation;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.ProductRequestValidators
{
    public class GetProductRequestByIdValidator : AbstractValidator<GetProductRequestByIdVM>
    {
        public GetProductRequestByIdValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Satın alınacak ürün kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alınacak ürün kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
