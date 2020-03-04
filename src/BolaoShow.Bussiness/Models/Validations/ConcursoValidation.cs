using FluentValidation;

namespace BolaoShow.Bussiness.Models.Validations
{
    public class ConcursoValidation : AbstractValidator<Concurso>
    {
        public ConcursoValidation()
        {
            RuleFor(c => c.DataFimConcurso)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(c => c.DataInicioConcurso)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
