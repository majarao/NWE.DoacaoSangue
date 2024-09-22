using MediatR;
using NWE.DoacaoSangue.Domain.Enums;

namespace NWE.DoacaoSangue.Application.DoadorUseCases.Commands.NovoDoador;

public class NovoDoadorCommand : IRequest<NovoDoadorResult>
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly DataNascimento { get; set; }
    public EGenero Genero { get; set; }
    public double Peso { get; set; }
    public ETipoSanguineo TipoSanguineo { get; set; }
    public EFatorRH FatorRH { get; set; }
    public string? CEP { get; set; }
}
