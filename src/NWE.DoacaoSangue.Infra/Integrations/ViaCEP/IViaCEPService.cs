namespace NWE.DoacaoSangue.Infra.Integrations.ViaCEP;

public interface IViaCEPService
{
    public ViaCEPModel RecuperarEnderecoPeloCEP(string CEP);
}
