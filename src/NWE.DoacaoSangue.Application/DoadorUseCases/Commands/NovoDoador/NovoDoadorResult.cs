namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;

public record NovoDoadorResult(
    Guid Id,
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    string Genero,
    double Peso,
    string TipoSanguineo,
    string FatorRh);
