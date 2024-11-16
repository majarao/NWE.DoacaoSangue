using MediatR;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.AtualizaDoador;

public record AtualizaDoadorCommand(Guid Id, string Email, double Peso, string? CEP) : IRequest<AtualizaDoadorResult>;
