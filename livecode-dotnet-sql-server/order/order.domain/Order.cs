namespace order.domain;

public class Order
{
    public Customer Customer { get; set; }

    public List<OrderItem> Items { get; set; }

    public int TotalPrice { get; set; }
}