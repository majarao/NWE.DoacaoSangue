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
        NomeCompleto = nomeCompleto;
        Email = email;
        DataNascimento = dataNascimento;
        Genero = genero;
        Peso = peso;
        TipoSanguineo = tipoSanguineo;
        FatorRH = fatorRH;
        Endereco = endereco;

        ValidaDoador(repository);
    }

    public void Atualiza(IDoadorRepository repository, string email, double peso, Endereco? endereco)
    {
        Email = email;
        Peso = peso;
        Endereco = endereco;

        ValidaDoador(repository);
    }

    private void ValidaDoador(IDoadorRepository repository)
    {
        if (repository.EmailJaUsado(Id, Email))
            throw new DoadorEmailUtilizadoException();

        if (Peso <= 50)
            throw new DoadorPesoMinimoException();

        if (DateTime.Now.Year - DataNascimento.Year < 16)
            throw new DoadorPrecisaTer16AnosException();
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
