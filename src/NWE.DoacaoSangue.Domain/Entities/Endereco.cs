using NWE.DoacaoSangue.Domain.Exceptions;
using NWE.DoacaoSangue.Domain.Integrations;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Endereco : Entity
{
    protected Endereco() { }

    public Endereco(ICEPService cepService, string cep)
    {
        Task<CEPModel?> model = cepService.RecuperarEnderecoPeloCEPAsync(cep);

        if (model.Result is null)
            throw new DoadorCEPException();

        if (model.Result.Logradouro is null)
            throw new DoadorCEPException("CEP não encontrado");

        CEP = cep;
        Logradouro = model.Result.Logradouro;
        Cidade = model.Result.Localidade!;
        Estado = model.Result.UF!;
    }

    public string CEP { get; private set; } = string.Empty;
    public string Logradouro { get; private set; } = string.Empty;
    public string Cidade { get; private set; } = string.Empty;
    public string Estado { get; private set; } = string.Empty;
    public Guid DoadorId { get; private set; }
    public Doador Doador { get; private set; } = null!;
}
