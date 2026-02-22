namespace Application.DTOs;

public class OrderResponseDto
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }

    public CustomerResponseDto? Customer { get; set; }
    public List<ProductResponseDto> Products { get; set; } = new();
}
