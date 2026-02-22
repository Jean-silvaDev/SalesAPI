namespace Application.UseCases.Order.CreateOrder;

public class CreateOrderCommand
{
    public Guid CustomerId { get; set; }
    public string? Description { get; set; }
    public List<Guid> ProductIds { get; set; } = new();
}
