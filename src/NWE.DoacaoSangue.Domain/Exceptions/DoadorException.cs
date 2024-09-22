namespace NWE.DoacaoSangue.Domain.Exceptions;

public class DoadorEmailUtilizadoException : Exception
{
    public DoadorEmailUtilizadoException() : base("E-mail já utilizado") { }
}

public class DoadorPesoMinimoException : Exception
{
    public DoadorPesoMinimoException() : base("É necessário pesar pelo menos 50kg") { }
}

public class DoadorPrecisaTer16AnosException : Exception
{
    public DoadorPrecisaTer16AnosException() : base("Doador precisa ter 16 anos") { }
}

public class DoadorCEPException : Exception
{
    public DoadorCEPException() : base("CEP inválido ou não existe") { }

    public DoadorCEPException(string message) : base(message) { }
}