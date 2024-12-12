using NWE.DoacaoSangue.Domain.Enums;

namespace NWE.DoacaoSangue.Domain.Entities;

public class DoacaoEstoque : Entity
{
    protected DoacaoEstoque() { }

    public DoacaoEstoque(ETipoSanguineo tipoSanguineo, EFatorRH fatorRH, int quantidadeML)
    {
        TipoSanguineo = tipoSanguineo;
        FatorRH = fatorRH;
        QuantidadeML = quantidadeML;
    }

    public ETipoSanguineo TipoSanguineo { get; private set; }
    public EFatorRH FatorRH { get; private set; }
    public int QuantidadeML { get; private set; }
}
