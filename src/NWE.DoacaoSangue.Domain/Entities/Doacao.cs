using NWE.DoacaoSangue.Core.Entities;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Doacao : Entity
{
    protected Doacao() { }

    public Doacao(Guid doadorId, DateTime dataDoacao, int quantidadeML)
    {
        DoadorId = doadorId;
        DataDoacao = dataDoacao;
        QuantidadeML = quantidadeML;
    }

    public Guid DoadorId { get; }
    public DateTime DataDoacao { get; }
    public int QuantidadeML { get; }
    public Doador? Doador { get; }
}
