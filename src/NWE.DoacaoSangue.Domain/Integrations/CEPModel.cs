namespace NWE.DoacaoSangue.Domain.Integrations;

public record CEPModel(
    string? CEP,
    string? Logradouro,
    string? Complemento,
    string? Unidade,
    string? Bairro,
    string? Localidade,
    string? UF,
    string? Estado,
    string? Regiao,
    string? IBGE,
    string? GIA,
    string? DDD,
    string? SIAFI);
