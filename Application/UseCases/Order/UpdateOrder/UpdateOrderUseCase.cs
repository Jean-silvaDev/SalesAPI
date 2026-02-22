using Application.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Order.UpdateOrder;

public class UpdateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateOrderUseCase(
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponseDto?> ExecuteAsync(Guid id, UpdateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var order = await _orderRepository.GetByIdAsync(id, cancellationToken);
        if (order is null)
            throw new Exception("Order not found");
        var customer = await _customerRepository.GetByIdAsync(command.CustomerId, cancellationToken);
        if (customer is null)
            throw new Exception("Customer not found");

        var products = await _productRepository.GetByIdsAsync(command.ProductIds, cancellationToken);

        order.CustomerId = command.CustomerId;
        order.Description = command.Description;
        order.Products = products.ToList();

        var resultOrder = await _orderRepository.UpdateAsync(id, order, cancellationToken);
        await _orderRepository.CommitAsync(cancellationToken);

        if (resultOrder == null)
            return null;

        return _mapper.Map<OrderResponseDto>(resultOrder);
    }
}
