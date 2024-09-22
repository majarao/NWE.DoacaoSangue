using NWE.DoacaoSangue.Domain.Enums;
using System.Diagnostics;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorById;

public record DoadorByIdResult(
    Guid Id,
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    EGenero Genero,
    double Peso,
    ETipoSanguineo TipoSanguineo,
    EFatorRH FatorRh);
