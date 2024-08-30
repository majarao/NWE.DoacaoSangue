namespace NWE.DoacaoSangue.Infra.Data;

public class UnitOfWork(DoacaoSangueContext context) : IUnitOfWork
{
    public DoacaoSangueContext Context { get; set; } = context;

    public Task<int> CommitAsync() => Context.SaveChangesAsync();
}
