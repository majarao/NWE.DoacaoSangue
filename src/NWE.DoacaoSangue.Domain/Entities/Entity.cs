namespace NWE.DoacaoSangue.Domain.Entities;

public class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}
