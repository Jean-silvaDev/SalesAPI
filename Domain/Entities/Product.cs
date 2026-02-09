namespace Domain.Entities;

public class Product
{
    public Guid Id { get; } = Guid.NewGuid();
    public string? Name { get; set; }
    public decimal Price { get; set; }
}
