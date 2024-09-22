using NWE.DoacaoSangue.Domain.Enums;
using NWE.DoacaoSangue.Domain.Exceptions;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Shared.Entities;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Doador : Entity
{
    protected Doador() { }

    public Doador(
        IDoadorRepository repository,
        string nomeCompleto,
        string email,
        DateOnly dataNascimento,
        EGenero genero,
        double peso,
        ETipoSanguineo tipoSanguineo,
        EFatorRH fatorRH,
        Endereco? endereco)
    {
        if (repository.GetByEmailAsync(email).Result != Guid.Empty)
            throw new DoadorEmailUtilizadoException();

        if (peso <= 50)
            throw new DoadorPesoMinimoException();

        if (DateTime.Now.Year - dataNascimento.Year < 16)
            throw new DoadorPrecisaTer16AnosException();

        NomeCompleto = nomeCompleto;
        Email = email;
        DataNascimento = dataNascimento;
        Genero = genero;
        Peso = peso;
        TipoSanguineo = tipoSanguineo;
        FatorRH = fatorRH;
        Endereco = endereco;
    }

    public string NomeCompleto { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateOnly DataNascimento { get; private set; }
    public EGenero Genero { get; private set; }
    public double Peso { get; private set; }
    public ETipoSanguineo TipoSanguineo { get; private set; }
    public EFatorRH FatorRH { get; private set; }
    public Endereco? Endereco { get; private set; }
    public List<Doacao>? Doacoes { get; private set; }
}
