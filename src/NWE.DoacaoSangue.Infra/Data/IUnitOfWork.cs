namespace NWE.DoacaoSangue.Infra.Data;

public interface IUnitOfWork
{
    public DoacaoSangueContext Context { get; set; }

    public Task<int> CommitAsync();
}
