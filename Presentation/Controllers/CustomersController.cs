using Application.UseCases.Customers.CreateCustomer;
using Application.UseCases.Customers.DeleteCustomer;
using Application.UseCases.Customers.GetAllCustomers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CreateCustomerUseCase _createUseCase;
    private readonly GetAllCustomersUseCase _getAllUseCase;
    private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase;
    private readonly UpdateCustomerUseCase _updateCustomerUseCase;
    private readonly DeleteCustomerUseCase _deleteCustomerUseCase;

    public CustomersController(
        CreateCustomerUseCase createUseCase,
        GetAllCustomersUseCase getAllUseCase,
        GetCustomerByIdUseCase getCustomerByIdUseCase,
        UpdateCustomerUseCase updateCustomerUseCase,
        DeleteCustomerUseCase deleteCustomerUseCase)
    {
        _createUseCase = createUseCase;
        _getAllUseCase = getAllUseCase;
        _getCustomerByIdUseCase = getCustomerByIdUseCase;
        _updateCustomerUseCase = updateCustomerUseCase;
        _deleteCustomerUseCase = deleteCustomerUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _createUseCase.ExecuteAsync(command, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var customers = await _getAllUseCase.ExecuteAsync(cancellationToken);
        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var customer = await _getCustomerByIdUseCase
            .ExecuteAsync(new GetCustomerByIdCommand { Id = id }, cancellationToken);

        if (customer is null)
            return NotFound();

        return Ok(customer);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateCustomerCommand command,
        CancellationToken cancellationToken)
    {
        var updatedCustomer = await _updateCustomerUseCase
            .ExecuteAsync(id, command, cancellationToken);

        if (updatedCustomer is null)
            return NotFound();

        return Ok(updatedCustomer);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _deleteCustomerUseCase.ExecuteAsync(id, cancellationToken);

        return NoContent();
    }
}