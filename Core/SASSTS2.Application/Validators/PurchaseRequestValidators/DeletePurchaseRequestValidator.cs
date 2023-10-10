using FluentValidation;
using SASSTS2.Application.Models.RequestModels.PurchaseRequestsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.PurchaseRequestValidators
{
    public class DeletePurchaseRequestValidator : AbstractValidator<DeletePurchaseRequestVM>
    {
        public DeletePurchaseRequestValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Satın alım talep kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alım talep kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
