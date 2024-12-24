using NWE.DoacaoSangue.Application.Models;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoacoesDoDoador;

public record DoacoesDoDoadorResult(
    Guid Id,
    string NomeCompleto,
    string TipoSanguineo,
    string FatorRh,
    List<DoacaoModel>? Doacoes);
