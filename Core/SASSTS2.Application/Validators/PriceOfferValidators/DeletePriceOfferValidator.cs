using FluentValidation;
using SASSTS2.Application.Models.RequestModels.PriceOffersRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.PriceOfferValidators
{
    public class DeletePriceOfferValidator : AbstractValidator<DeletePriceOfferVM>
    {
        public DeletePriceOfferValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Gelen teklif kimlik numarası boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Gelen teklif kimlik numarası sıfırdan büyük olmalıdır.");
        }
    }
}
