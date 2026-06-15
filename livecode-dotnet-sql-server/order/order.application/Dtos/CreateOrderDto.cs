namespace order.application.Dtos;

public class CreateOrderDto
{
    [Required]
    public List<CreateOrderItemDto> Items { get; set; }

    [Required]
    public int TotalPrice { get; set; }
}
