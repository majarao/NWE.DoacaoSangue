using MediatR;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorGetAll;

public record DoadorGetAllQuery : IRequest<List<DoadorGetAllResult>?>;
