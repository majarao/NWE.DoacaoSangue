using MediatR;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoacoesDoDoador;

public record DoacoesDoDoadorQuery(Guid Id) : IRequest<DoacoesDoDoadorResult?>;
