using NWE.DoacaoSangue.Application.Models;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorByIdComEndereco;

public record DoadorByIdComEnderecoResult(
    Guid Id,
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    string Genero,
    double Peso,
    string TipoSanguineo,
    string FatorRh,
    EnderecoModel? Endereco);
