using NWE.DoacaoSangue.Application.Models;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.AtualizaDoador;

public record AtualizaDoadorResult(
    Guid Id,
    string Email,
    double Peso,
    EnderecoModel? Endereco);
