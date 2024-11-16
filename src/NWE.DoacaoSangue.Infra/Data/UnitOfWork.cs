namespace NWE.DoacaoSangue.Infra.Data;

public class UnitOfWork(DoacaoSangueContext context) : IUnitOfWork
{
    public DoacaoSangueContext Context { get; set; } = context;

    public async Task<int> CommitAsync() => await Context.SaveChangesAsync();
}
