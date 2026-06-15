namespace order.domain;

public class Inventory
{
    public int Id { get; set; }

    public Product Product { get; set; }

    public int Availability { get; set; }
}