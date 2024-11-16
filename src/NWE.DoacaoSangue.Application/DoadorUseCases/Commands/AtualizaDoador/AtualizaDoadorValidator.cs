using FluentValidation;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.AtualizaDoador;

public class AtualizaDoadorValidator : AbstractValidator<AtualizaDoadorCommand>
{
    public AtualizaDoadorValidator()
    {
        RuleFor(d => d.Email)
            .NotEmpty().WithMessage("Necessário informar o e-mail")
            .NotNull().WithMessage("Necessário informar o e-mail")
            .EmailAddress().WithMessage("Esse e-mail não é válido");

        RuleFor(d => d.Peso)
            .NotEmpty().WithMessage("Necessário informar o peso")
            .NotNull().WithMessage("Necessário informar o peso")
            .GreaterThan(50).WithMessage("O peso precisa ser maior que 50");

        RuleFor(d => d.CEP)
            .Matches(@"^\d{5}-\d{3}$").WithMessage("CEP inválido");
    }
}
