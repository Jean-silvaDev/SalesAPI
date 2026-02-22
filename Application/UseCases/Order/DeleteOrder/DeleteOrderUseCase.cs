using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Order.DeleteOrder
{
    public class DeleteOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderUseCase(
            IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task ExecuteAsync(Guid id, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(id, cancellationToken);
            if (order is null)
                throw new ArgumentNullException("Order not found!");

            await _orderRepository.DeleteAsync(id, cancellationToken);
            await _orderRepository.CommitAsync(cancellationToken);
        }
    }
}
