using NWE.DoacaoSangue.Application.DTOs;
using NWE.DoacaoSangue.Domain.Enums;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Querys.DoadorByIdComEndereco;

public record DoadorByIdComEnderecoResult(
    Guid Id,
    string NomeCompleto,
    string Email,
    DateOnly DataNascimento,
    EGenero Genero,
    double Peso,
    ETipoSanguineo TipoSanguineo,
    EFatorRH FatorRh,
    EnderecoDTO? Endereco);
