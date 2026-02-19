using Application.UseCases.Customers.CreateCustomer;
using Application.UseCases.Customers.GetAllCustomers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly DeleteCustomerUseCase _createUseCase;
    private readonly GetAllCustomersUseCase _getAllUseCase;

    public CustomersController(
        DeleteCustomerUseCase createUseCase,
        GetAllCustomersUseCase getAllUseCase)
    {
        _createUseCase = createUseCase;
        _getAllUseCase = getAllUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(DeleteCustomerCommand command, CancellationToken cancellationToken = default)
    {
        var id = await _createUseCase.ExecuteAsync(command, cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var customers = await _getAllUseCase.ExecuteAsync(cancellationToken);
        return Ok(customers);
    }
}