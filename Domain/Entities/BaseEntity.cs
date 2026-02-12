using Domain.Common;

namespace Domain.Entities;

public abstract class BaseEntity : IAuditable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime InsertedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
