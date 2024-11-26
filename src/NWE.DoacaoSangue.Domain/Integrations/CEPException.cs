namespace NWE.DoacaoSangue.Domain.Integrations;

public class CEPException : Exception
{
    public CEPException() : base("CEP inválido") { }
}
