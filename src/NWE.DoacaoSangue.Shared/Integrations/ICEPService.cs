using System.Text.RegularExpressions;

namespace NWE.DoacaoSangue.Shared.Integrations;

public interface ICEPService
{
    public Task<CEPModel?> RecuperarEnderecoPeloCEPAsync(string cep);

    public static void ValidarCEP(string cep)
    {
        Regex regex = new(@"^\d{5}-\d{3}$");

        if (!regex.IsMatch(cep))
            throw new CEPException();
    }
}
