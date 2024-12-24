namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorById;

public record DoadorByIdResult(
    Guid Id,
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    string Genero,
    double Peso,
    string TipoSanguineo,
    string FatorRh);
