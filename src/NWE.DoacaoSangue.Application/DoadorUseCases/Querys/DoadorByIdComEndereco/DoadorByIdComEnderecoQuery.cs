using MediatR;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorByIdComEndereco;

public record DoadorByIdComEnderecoQuery(Guid Id) : IRequest<DoadorByIdComEnderecoResult>;
