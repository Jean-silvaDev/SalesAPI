using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Order.GetOrderById
{
    public class GetOrderByIdUseCase
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderByIdUseCase(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderResponseDto?> ExecuteAsync(Guid orderId, CancellationToken cancellationToken = default)
        {
            var order = await _repository.GetByIdWithDetailsAsync(orderId, cancellationToken);

            if (order == null)
                return null;

            return _mapper.Map<OrderResponseDto>(order);
        }
    }
}
