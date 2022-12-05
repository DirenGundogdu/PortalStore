namespace DTO;

public class OrderDto : BaseDto
{
    public int CustomerId { get; set; }

    public int AddressId { get; set; }

    public decimal TotalPrice { get; set; }
}
