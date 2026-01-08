using Domain.Enums;

namespace Application.DTOs;

public record CreateProductDto
(
    string? name,
    string? description,
    decimal? price,
    ProductType? type
);
