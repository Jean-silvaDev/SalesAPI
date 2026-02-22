namespace Application.UseCases.Order.UpdateOrder;

public class UpdateOrderCommand
{
    public Guid CustomerId { get; set; }
    public string? Description { get; set; }
    public List<Guid> ProductIds { get; set; } = new();
}
