using MediatR;

namespace NWE.DoacaoSangue.Application.DoacaoUseCases.Commands.NovaDoacao;

public record NovaDoacaoCommand(Guid DoadorId, DateTime DataDoacao, int QuantidadeML) : IRequest<NovaDoacaoResut>;
