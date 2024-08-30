using NWE.DoacaoSangue.Core.Entities;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Endereco : Entity
{
    protected Endereco() { }

    public Endereco(string logradouro, string cidade, string estado, string cep)
    {
        Logradouro = logradouro;
        Cidade = cidade;
        Estado = estado;
        CEP = cep;
    }

    public string Logradouro { get; } = string.Empty;
    public string Cidade { get; } = string.Empty;
    public string Estado { get; } = string.Empty;
    public string CEP { get; } = string.Empty;
    public Guid? DoadorId { get; }
    public Doador? Doador { get; }
}
