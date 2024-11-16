using MediatR;
using NWE.DoacaoSangue.Domain.Enums;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;

public record NovoDoadorCommand(
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    EGenero Genero,
    double Peso,
    ETipoSanguineo TipoSanguineo,
    EFatorRH FatorRH,
    string? CEP) : IRequest<NovoDoadorResult>;
