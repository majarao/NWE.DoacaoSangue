namespace NWE.DoacaoSangue.Shared.Entities;

public class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}
