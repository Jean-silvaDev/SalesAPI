namespace Domain.Common;

public interface IAuditable
{
    DateTime InsertedDate { get; set; }
    DateTime? UpdatedDate { get; set; }
}
