using NWE.DoacaoSangue.Domain.Entities;
using NWE.DoacaoSangue.Domain.Models;

namespace NWE.DoacaoSangue.Domain.Repositories;

public interface IDoacaoRepository
{
    public Task<Doacao?> RecuperaUltimaDoacaoDoDoadorAsync(Guid doadorId);
    public Task<Doacao> CreateAsync(Doacao doacao);
    public Task<List<Estoque>> GetEstoqueAsync();
    public Task<List<Estoque>> GetEstoqueMinimoAsync(int abaixoMinimo);
}
