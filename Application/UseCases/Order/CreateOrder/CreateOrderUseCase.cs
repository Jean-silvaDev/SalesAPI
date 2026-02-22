using Application.UseCases.Order.CreateOrder;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;

    public CreateOrderUseCase(
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }

    public async Task<Guid> ExecuteAsync(CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetByIdAsync(command.CustomerId, cancellationToken);
        if (customer is null)
            throw new Exception("Customer not found");

        var products = await _productRepository.GetByIdsAsync(command.ProductIds, cancellationToken);

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = command.CustomerId,
            CreatedDate = DateTime.UtcNow,
            Description = command.Description,
            Products = products.ToList()
        };

        await _orderRepository.SaveAsync(order, cancellationToken);
        await _orderRepository.CommitAsync(cancellationToken);

        return order.Id;
    }
}