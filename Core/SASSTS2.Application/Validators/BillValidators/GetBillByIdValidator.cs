using FluentValidation;
using SASSTS2.Application.Models.RequestModels.BillsRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Application.Validators.BillValidators
{
    public class GetBillByIdValidator : AbstractValidator<GetBillByIdVM>
    {
        public GetBillByIdValidator() 
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Fatura kimlik numarası boş brakılamaz.");
        }
    }
}
