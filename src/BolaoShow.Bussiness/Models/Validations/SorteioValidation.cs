using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoShow.Bussiness.Models.Validations
{
    public class SorteioValidation : AbstractValidator<Sorteio>
    {
        public SorteioValidation()
        {
            RuleFor(s => s.Dezena_01)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(s => s.Dezena_02)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(s => s.Dezena_03)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(s => s.Dezena_04)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(s => s.Dezena_05)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }
    }
}
