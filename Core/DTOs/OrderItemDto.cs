using Core.Entities;

namespace Core.DTOs;

public abstract class OrderItemDto
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }
}
