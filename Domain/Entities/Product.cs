using Domain.Enums;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public ProductType? Type { get; set; }
        public DateTime InsertAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
