using NWE.DoacaoSangue.Domain.Enums;
using NWE.DoacaoSangue.Shared.Entities;

namespace NWE.DoacaoSangue.Domain.Entities;

public class EstoqueSangue : Entity
{
    protected EstoqueSangue() { }

    public EstoqueSangue(ETipoSanguineo tipoSanguineo, EFatorRh fatorRh, int quantidadeML)
    {
        TipoSanguineo = tipoSanguineo;
        FatorRh = fatorRh;
        QuantidadeML = quantidadeML;
    }

    public ETipoSanguineo TipoSanguineo { get; }
    public EFatorRh FatorRh { get; }
    public int QuantidadeML { get; }
}
