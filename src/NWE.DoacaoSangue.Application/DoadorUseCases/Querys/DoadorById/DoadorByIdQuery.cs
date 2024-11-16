using MediatR;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorById;

public record DoadorByIdQuery(Guid Id) : IRequest<DoadorByIdResult>;
