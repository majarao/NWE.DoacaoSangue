using NWE.DoacaoSangue.Core.Entities;
using NWE.DoacaoSangue.Domain.Enums;

namespace NWE.DoacaoSangue.Domain.Entities;

public class Doador : Entity
{
    protected Doador() { }

    public Doador(string nomeCompleto, string email, DateOnly dataNascimento, char genero, double peso, ETipoSanguineo tipoSanguineo, EFatorRh fatorRh, Endereco? endereco)
    {
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
    public char Genero { get; }
    public double Peso { get; }
    public ETipoSanguineo TipoSanguineo { get; }
    public EFatorRh FatorRh { get; }
    public Guid? EnderecoId { get; }
    public Endereco? Endereco { get; }
    public List<Doacao>? Doacoes { get; }
}
