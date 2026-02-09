namespace Domain.Entities;

public class Customer
{
    public Guid Id { get; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CPF { get; set; }
    public string? PhoneNumber { get; set; }
}
