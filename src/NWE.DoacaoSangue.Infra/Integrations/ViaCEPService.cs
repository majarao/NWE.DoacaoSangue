using NWE.DoacaoSangue.Shared.Integrations;
using System.Net.Http.Json;

namespace NWE.DoacaoSangue.Infra.Integrations;

public class ViaCEPService : ICEPService
{
    public HttpClient Client { get; }

    public ViaCEPService(IHttpClientFactory client)
    {
        Client = client.CreateClient();
        Client.BaseAddress = new Uri("https://viacep.com.br");
    }

    public async Task<CEPModel?> RecuperarEnderecoPeloCEPAsync(string cep)
    {
        ICEPService.ValidarCEP(cep);

        CEPModel? model = await Client.GetFromJsonAsync<CEPModel>($"/ws/{cep}/json/");

        return model;
    }
}
