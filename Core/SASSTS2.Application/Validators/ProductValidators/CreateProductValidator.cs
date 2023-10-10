using FluentValidation;
using SASSTS2.Application.Models.RequestModels.ProductsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.ProductValidators
{
    public class CreateProductValidator : AbstractValidator<CreateProductVM>
    {
        public CreateProductValidator() 
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Kategori kimlik numarası sıfırdan büyük olmalıdır.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                .MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olabilir.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Ürün mikterı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Ürün birim fiyatı sıfırdan büyük olmalıdır.");
        }
    }
}
