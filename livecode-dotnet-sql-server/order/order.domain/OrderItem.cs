namespace order.domain;

public class OrderItem
{
    public int Id { get; set; }

    // Price for the order item.
    // Product price may be updated later 
    public int Price { get; set; }

    public int Quantity { get; set; }

    public Product Product { get; set; }
}
