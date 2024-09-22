using FluentValidation;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;

public class NovoDoadorValidator : AbstractValidator<NovoDoadorCommand>
{
    public NovoDoadorValidator()
    {
        RuleFor(d => d.NomeCompleto)
            .NotEmpty().WithMessage("Necessário informar o nome completo")
            .NotNull().WithMessage("Necessário informar o nome completo")
            .MaximumLength(100).WithMessage("Nome completo não pode ter mais de 100 caracteres");

        RuleFor(d => d.Email)
            .NotEmpty().WithMessage("Necessário informar o e-mail")
            .NotNull().WithMessage("Necessário informar o e-mail")
            .EmailAddress().WithMessage("Esse e-mail não é válido");

        RuleFor(d => d.DataNascimento)
            .NotEmpty().WithMessage("Necessário informar a data de nascimento")
            .NotNull().WithMessage("Necessário informar a data de nascimento");

        RuleFor(d => d.Genero)
            .NotNull().WithMessage("Necessário informar o genêro")
            .IsInEnum().WithMessage("Valor inválido para o genêro");

        RuleFor(d => d.Peso)
            .NotEmpty().WithMessage("Necessário informar o peso")
            .NotNull().WithMessage("Necessário informar o peso")
            .GreaterThan(50).WithMessage("O peso precisa ser maior que 50");

        RuleFor(d => d.TipoSanguineo)
            .NotNull().WithMessage("Necessário informar o tipo sanguíneo")
            .IsInEnum().WithMessage("Valor inválido para o tipo sanguíneo");

        RuleFor(d => d.FatorRH)
            .NotNull().WithMessage("Necessário informar o fator RH")
            .IsInEnum().WithMessage("Valor inválido para o fator RH");

        RuleFor(d => d.CEP)
            .Matches(@"^\d{5}-\d{3}$").WithMessage("CEP inválido");
    }
}
