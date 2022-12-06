namespace DTO;

public class BasketProcessDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Quantity { get; set; }
    public int AddressId { get; set; }
    public decimal TotalPrice { get; set; }
}
