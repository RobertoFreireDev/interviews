namespace order.application.Dtos.DataContracts.Request;

public class CreateOrderRequest
{
    [Required]
    public CreateOrderDto Order { get; set; }
}
