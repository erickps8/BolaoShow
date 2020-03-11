using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolaoShow.Bussiness.Models.Validations
{
    public class ApostaValidation : AbstractValidator<Aposta>
    {
        public ApostaValidation()
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
            RuleFor(s => s.Dezena_06)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(s => s.Dezena_07)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(s => s.Dezena_08)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(s => s.Dezena_09)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(s => s.Dezena_10)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

        }
    }
}
