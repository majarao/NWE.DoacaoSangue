using NWE.DoacaoSangue.Domain.Enums;
using NWE.DoacaoSangue.Domain.Exceptions;
using NWE.DoacaoSangue.Domain.Repositories;
using NWE.DoacaoSangue.Shared.Entities;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Doador : Entity
{
    private IDoadorRepository? Repository { get; }

    protected Doador() { }

    public Doador(
        IDoadorRepository repository,
        string nomeCompleto,
        string email,
        DateOnly dataNascimento,
        EGenero genero,
        double peso,
        ETipoSanguineo tipoSanguineo,
        EFatorRh fatorRh,
        Endereco? endereco)
    {
        Repository = repository;

        if (Repository.GetByEmailAsync(email).Result != Guid.Empty)
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
        FatorRh = fatorRh;
        Endereco = endereco;
    }

    public string NomeCompleto { get; } = string.Empty;
    public string Email { get; } = string.Empty;
    public DateOnly DataNascimento { get; }
    public EGenero Genero { get; }
    public double Peso { get; }
    public ETipoSanguineo TipoSanguineo { get; }
    public EFatorRh FatorRh { get; }
    public Guid? EnderecoId { get; }
    public Endereco? Endereco { get; }
    public List<Doacao>? Doacoes { get; }
}
