using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Order
        CreateMap<Order, OrderResponseDto>();

        // Customer
        CreateMap<Customer, CustomerResponseDto>();

        // Product
        CreateMap<Product, ProductResponseDto>();
    }
}
