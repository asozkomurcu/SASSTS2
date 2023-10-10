using FluentValidation;
using SASSTS2.Application.Models.RequestModels.ProductRequestsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.ProductRequestValidators
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequestVM>
    {
        public UpdateProductRequestValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Satın alınacak ürün listesi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alınacak ürün listesi kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.PurchaseRequestId)
                .NotEmpty().WithMessage("Satın alım talebi kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Satın alım talebi kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Kullanıcı kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kullanıcı kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Personel adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Personel adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.ProductDescription)
                .NotEmpty().WithMessage("Ürün açıklaması boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Ürün açıklaması en fazla 500 karakter olabilir.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Ürün mikterı boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Ürün mikterı sıfırdan büyük olmalıdır.");
        }
    }
}
