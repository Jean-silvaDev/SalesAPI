using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using AutoMapper;
using Domain.Interfaces.Repositories;

namespace Application.UseCases.Order.GetAllOrders;

public class GetAllOrdersUseCase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetAllOrdersUseCase(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderResponseDto>> ExecuteAsync(CancellationToken cancellationToken = default) 
        => _mapper.Map<IEnumerable<OrderResponseDto>>(await _orderRepository.GetAllWithDetailsAsync(cancellationToken));
}
