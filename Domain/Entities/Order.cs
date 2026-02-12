namespace Domain.Entities;

public class Order : BaseEntity
{
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}