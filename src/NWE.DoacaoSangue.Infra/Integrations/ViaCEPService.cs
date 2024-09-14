using NWE.DoacaoSangue.Shared.Integrations;
using System.Net.Http.Json;
using System.Text.Json;

namespace NWE.DoacaoSangue.Infra.Integrations;

public class ViaCEPService : ICEPService
{
    public HttpClient Client { get; }
    private JsonSerializerOptions Options { get; } = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    public ViaCEPService(IHttpClientFactory client)
    {
        Client = client.CreateClient();
        Client.BaseAddress = new Uri("https://viacep.com.br");
    }

    public async Task<CEPModel?> RecuperarEnderecoPeloCEPAsync(string cep)
    {
        ICEPService.ValidarCEP(cep);

        return await Client.GetFromJsonAsync<CEPModel>($"/ws/{cep}/json/");
    }
}
