namespace DTO;

public class OrderItemDto : BaseDto
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }
}
