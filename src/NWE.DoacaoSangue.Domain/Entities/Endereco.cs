using NWE.DoacaoSangue.Core.Entities;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Endereco : Entity
{
    protected Endereco() { }

    public Endereco(Guid doadorId, string cep, string logradouro, string cidade, string estado)
    {
        DoadorId = doadorId;
        CEP = cep;
        Logradouro = logradouro;
        Cidade = cidade;
        Estado = estado;
    }

    public string CEP { get; } = string.Empty;
    public string Logradouro { get; } = string.Empty;
    public string Cidade { get; } = string.Empty;
    public string Estado { get; } = string.Empty;
    public Guid DoadorId { get; }
    public Doador Doador { get; } = null!;
}
