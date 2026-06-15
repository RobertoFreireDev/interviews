namespace order.domain;

public class Product
{
    public int Id { get; set; }

    public string Sku { get; set; }

    public string Name { get; set; }

    // 1280 -> 12,80 $
    public int Price { get; set; }
}
