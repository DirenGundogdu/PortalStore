namespace DTO;

public class BasketDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int CustomerId { get; set; }
    public CustomerDto Customer { get; set; }
    public int Quantity { get; set; }
}
