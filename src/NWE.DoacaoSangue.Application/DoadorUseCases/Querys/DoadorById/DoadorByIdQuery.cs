using MediatR;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorById;

public class DoadorByIdQuery(Guid id) : IRequest<DoadorByIdResult>
{
    public Guid Id { get; private set; } = id;
}
