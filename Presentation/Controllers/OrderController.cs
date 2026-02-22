using Application.UseCases.Order.CreateOrder;
using Application.UseCases.Order.DeleteOrder;
using Application.UseCases.Order.GetAllOrders;
using Application.UseCases.Order.GetOrderById;
using Application.UseCases.Order.UpdateOrder;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly CreateOrderUseCase _createOrderUseCase;
    private readonly GetOrderByIdUseCase _getOrderByIdUseCase;
    private readonly GetAllOrdersUseCase _getAllOrdersUseCase;
    private readonly UpdateOrderUseCase _updateOrderUseCase;
    private readonly DeleteOrderUseCase _deleteOrderUseCase;

    public OrderController(CreateOrderUseCase createOrderUseCase, GetAllOrdersUseCase getAllOrdersUseCase, GetOrderByIdUseCase getOrderByIdUseCase, UpdateOrderUseCase updateOrderUseCase, DeleteOrderUseCase deleteOrderUseCase)
    {
        _createOrderUseCase = createOrderUseCase;
        _getAllOrdersUseCase = getAllOrdersUseCase;
        _getOrderByIdUseCase = getOrderByIdUseCase;
        _updateOrderUseCase = updateOrderUseCase;
        _deleteOrderUseCase = deleteOrderUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var id = await _createOrderUseCase.ExecuteAsync(command, cancellationToken);
        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var order = await _getOrderByIdUseCase.ExecuteAsync(id, cancellationToken);
        if (order is null)
            return NotFound();
        return Ok(order);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var customers = await _getAllOrdersUseCase.ExecuteAsync(cancellationToken);
        return Ok(customers);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _updateOrderUseCase.ExecuteAsync(id, command, cancellationToken);
        if (order is null)
            return NotFound();
        return Ok(order);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _deleteOrderUseCase.ExecuteAsync(id, cancellationToken);

        return NoContent();
    }
}