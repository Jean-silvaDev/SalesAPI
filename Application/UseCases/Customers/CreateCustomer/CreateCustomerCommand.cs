namespace Application.UseCases.Customers.CreateCustomer;

public class CreateCustomerCommand
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string CPF { get; set; } = default!;
    public string? PhoneNumber { get; set; }
}