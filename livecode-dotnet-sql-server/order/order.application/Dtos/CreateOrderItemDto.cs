namespace order.application.Dtos;

public class CreateOrderItemDto
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int Quantity { get; set; }
}