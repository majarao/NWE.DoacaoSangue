using MediatR;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorByIdComEndereco;

public class DoadorByIdComEnderecoQuery(Guid id) : IRequest<DoadorByIdComEnderecoResult>
{
    public Guid Id { get; private set; } = id;
}
