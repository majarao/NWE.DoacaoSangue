using NWE.DoacaoSangue.Application.DTOs;
using NWE.DoacaoSangue.Domain.Enums;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoacoesDoDoador;

public record DoacoesDoDoadorResult(
    Guid Id,
    string NomeCompleto,
    ETipoSanguineo TipoSanguineo,
    EFatorRH FatorRh,
    List<DoacaoDTO>? Doacoes);
