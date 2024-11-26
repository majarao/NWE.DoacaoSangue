using NWE.DoacaoSangue.Domain.Enums;
using NWE.DoacaoSangue.Domain.Exceptions;
using NWE.DoacaoSangue.Domain.Repositories;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Doacao : Entity
{
    protected Doacao() { }

    public Doacao(
        IDoadorRepository doadorRepository,
        IDoacaoRepository doacaoRepository,
        Guid doadorId,
        DateTime dataDoacao,
        int quantidadeML)
    {
        Doador? doador = doadorRepository.GetByIdAsync(doadorId).Result ??
            throw new DoacaoDoadorNaoEncontradoException();

        if (DateTime.Now.Year - doador.DataNascimento.Year < 18)
            throw new DoacaoDoadorMenorIdadeException();

        Doacao? ultimaDoacao = doacaoRepository.RecuperaUltimaDoacaoDoDoadorAsync(doadorId).Result;

        if (ultimaDoacao is not null)
        {
            switch (doador.Genero)
            {
                case EGenero.FEMININO:
                    if ((dataDoacao - ultimaDoacao.DataDoacao).Days < 90)
                        throw new DoacaoIntervaloParaMulheresException();
                    return;

                case EGenero.MASCULINO:
                    if ((dataDoacao - ultimaDoacao.DataDoacao).Days < 60)
                        throw new DoacaoIntervaloParaHomensException();
                    return;

                default:
                    return;
            }
        }

        if (quantidadeML < 420 || quantidadeML > 470)
            throw new DoacaoQuantidadeEsperadaException();

        DoadorId = doadorId;
        DataDoacao = dataDoacao;
        QuantidadeML = quantidadeML;
    }

    public Guid DoadorId { get; private set; }
    public Doador? Doador { get; private set; }
    public DateTime DataDoacao { get; private set; }
    public int QuantidadeML { get; private set; }
}
