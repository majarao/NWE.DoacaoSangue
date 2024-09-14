using NWE.DoacaoSangue.Domain.Exceptions;
using NWE.DoacaoSangue.Shared.Entities;
using NWE.DoacaoSangue.Shared.Integrations;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Endereco : Entity
{
    protected Endereco() { }

    public Endereco(ICEPService cepService, string cep)
    {
        Task<CEPModel?> model = cepService.RecuperarEnderecoPeloCEPAsync(cep);

        if (model.Result is null)
            throw new DoadorCEPException();

        CEP = cep;
        Logradouro = model.Result.Logradouro!;
        Cidade = model.Result.Localidade!;
        Estado = model.Result.Estado!;
    }

    public string CEP { get; } = string.Empty;
    public string Logradouro { get; } = string.Empty;
    public string Cidade { get; } = string.Empty;
    public string Estado { get; } = string.Empty;
    public Guid DoadorId { get; }
    public Doador Doador { get; } = null!;
}
