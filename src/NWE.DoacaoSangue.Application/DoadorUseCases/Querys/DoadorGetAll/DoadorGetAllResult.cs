namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorGetAll;

public record DoadorGetAllResult(
    Guid Id,
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    string Genero,
    double Peso,
    string TipoSanguineo,
    string FatorRh);
