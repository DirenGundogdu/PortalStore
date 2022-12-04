using Core.Entities;
using Data.DTOs;

namespace Core.DTOs;

public abstract class OrderDto : BaseDto
{
    public int CustomerId { get; set; }

    public int AddressId { get; set; }

    public decimal TotalPrice { get; set; }
}
