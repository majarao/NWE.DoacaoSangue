using NWE.DoacaoSangue.Application.DTOs;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.AtualizaDoador;

public record AtualizaDoadorResult(
    Guid Id,
    string Email,
    double Peso,
    EnderecoDTO? Endereco);
