using NWE.DoacaoSangue.Domain.Entities;

namespace NWE.DoacaoSangue.Domain.Repositories;

public interface IDoacaoRepository
{
    public Task<Doacao?> RecuperaUltimaDoacaoDoDoadorAsync(Guid doadorId);
    public Task<Doacao> CreateAsync(Doacao doacao);
}
