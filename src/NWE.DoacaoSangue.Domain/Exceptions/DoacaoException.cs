namespace NWE.DoacaoSangue.Domain.Exceptions;

public class DoacaoDoadorNaoEncontradoException : Exception
{
    public DoacaoDoadorNaoEncontradoException() : base("Doador não encontrado") { }
}

public class DoacaoDoadorMenorIdadeException : Exception
{
    public DoacaoDoadorMenorIdadeException() : base("Doador precisa ter mais de 18 anos") { }
}

public class DoacaoIntervaloParaMulheresException : Exception
{
    public DoacaoIntervaloParaMulheresException() : base("Mulheres só podem doar depois de 90 dias") { }
}

public class DoacaoIntervaloParaHomensException : Exception
{
    public DoacaoIntervaloParaHomensException() : base("Mulheres só podem doar depois de 60 dias") { }
}

public class DoacaoQuantidadeEsperadaException : Exception
{
    public DoacaoQuantidadeEsperadaException() : base("Quantidade de doação deve ser entre 420 e 470 ml") { }
}
