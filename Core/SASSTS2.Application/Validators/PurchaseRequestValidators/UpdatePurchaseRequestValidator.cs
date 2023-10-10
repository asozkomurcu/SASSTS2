using FluentValidation;
using SASSTS2.Application.Models.RequestModels.PurchaseRequestsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.PurchaseRequestValidators
{
    public class UpdatePurchaseRequestValidator : AbstractValidator<UpdatePurchaseRequestVM>
    {
        public UpdatePurchaseRequestValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Satın alım talep kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alım talep kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Kullanıcı kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kullanıcı kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Personel adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Ürün talep durumu boş bırakılamaz.")
                .IsInEnum();
        }
    }
}
