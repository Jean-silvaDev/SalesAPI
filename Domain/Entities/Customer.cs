namespace Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? CPF { get; set; }
    public DateTime InsertAt { get; set; }
    public DateTime UpdateAt { get; set; }
}
