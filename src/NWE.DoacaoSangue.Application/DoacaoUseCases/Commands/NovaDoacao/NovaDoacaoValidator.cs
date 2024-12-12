using FluentValidation;

namespace NWE.DoacaoSangue.Application.DoacaoUseCases.Commands.NovaDoacao;

public class NovaDoacaoValidator : AbstractValidator<NovaDoacaoCommand>
{
    public NovaDoacaoValidator()
    {
        RuleFor(d => d.QuantidadeML)
            .InclusiveBetween(420, 470)
            .WithMessage("Quantidade de doação deve ser entre 420 e 470 ml");
    }
}
