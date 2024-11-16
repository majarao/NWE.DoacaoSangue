using NWE.DoacaoSangue.Domain.Enums;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorGetAll;

public record DoadorGetAllResult(
    Guid Id,
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    EGenero Genero,
    double Peso,
    ETipoSanguineo TipoSanguineo,
    EFatorRH FatorRh);
