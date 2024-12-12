using NWE.DoacaoSangue.Application.Models;

namespace NWE.DoacaoSangue.Application.DoacaoUseCases.Commands.NovaDoacao;

public record NovaDoacaoResut(Guid Id, DoadorModel Doador, DateTime DataDoacao, int QuantidadeML);
