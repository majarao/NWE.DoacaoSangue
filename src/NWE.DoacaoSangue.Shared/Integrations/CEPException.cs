namespace NWE.DoacaoSangue.Shared.Integrations;

public class CEPException : Exception
{
    public CEPException() : base("CEP inválido") { }
}
