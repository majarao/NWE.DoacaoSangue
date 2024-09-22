using NWE.DoacaoSangue.Domain.Enums;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;

public record NovoDoadorResult(
    Guid Id,
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    EGenero Genero,
    double Peso,
    ETipoSanguineo TipoSanguineo,
    EFatorRH FatorRh);
