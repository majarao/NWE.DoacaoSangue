using System.Text.Json;
using System.Text.RegularExpressions;

namespace NWE.DoacaoSangue.Infra.Integrations.ViaCEP;

public class ViaCEPService : IViaCEPService
{
    public HttpClient Client { get; }
    private JsonSerializerOptions Options { get; } = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    public ViaCEPService(IHttpClientFactory client)
    {
        Client = client.CreateClient();
        Client.BaseAddress = new Uri("https://viacep.com.br");
    }

    public async Task<ViaCEPModel> RecuperarEnderecoPeloCEPAsync(string cep)
    {
        ValidarCEP(cep);

        HttpResponseMessage response = await Client.GetAsync($"/ws/{cep}/json/");

        if (response.IsSuccessStatusCode)
        {
            Stream stream = await response.Content.ReadAsStreamAsync();
            ViaCEPModel model = await JsonSerializer.DeserializeAsync<ViaCEPModel>(stream, Options) ?? new();

            return model;
        }

        return new();
    }

    public void ValidarCEP(string cep)
    {
        Regex regex = new(@"^\d{5}-\d{3}$");

        if (!regex.IsMatch(cep))
            throw new ViaCEPException();
    }
}
