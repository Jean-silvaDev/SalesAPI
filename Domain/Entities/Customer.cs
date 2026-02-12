namespace Domain.Entities;

public class Customer : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CPF { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();
}
