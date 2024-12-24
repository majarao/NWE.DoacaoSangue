using MediatR;
using NWE.DoacaoSangue.Domain.Models;

namespace NWE.DoacaoSangue.Application.DoacaoUseCases.Querys.GetEstoque;

public record GetEstoqueQuery : IRequest<List<Estoque>>;
