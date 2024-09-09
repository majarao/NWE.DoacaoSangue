namespace NWE.DoacaoSangue.Infra.Integrations.ViaCEP;

public class ViaCEPException : Exception
{
    public ViaCEPException() : base("CEP inválido") { }
}
