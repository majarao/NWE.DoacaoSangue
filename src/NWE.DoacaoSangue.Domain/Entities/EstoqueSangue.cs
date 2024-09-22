using NWE.DoacaoSangue.Domain.Enums;
using NWE.DoacaoSangue.Shared.Entities;

namespace NWE.DoacaoSangue.Domain.Entities;

public class EstoqueSangue : Entity
{
    protected EstoqueSangue() { }

    public EstoqueSangue(ETipoSanguineo tipoSanguineo, EFatorRH fatorRH, int quantidadeML)
    {
        TipoSanguineo = tipoSanguineo;
        FatorRH = fatorRH;
        QuantidadeML = quantidadeML;
    }

    public ETipoSanguineo TipoSanguineo { get; private set; }
    public EFatorRH FatorRH { get; private set; }
    public int QuantidadeML { get; private set; }
}
