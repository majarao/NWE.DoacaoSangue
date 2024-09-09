namespace NWE.DoacaoSangue.Infra.Integrations.ViaCEP;

public interface IViaCEPService
{
    public Task<ViaCEPModel> RecuperarEnderecoPeloCEPAsync(string cep);
    public void ValidarCEP(string cep);
}
