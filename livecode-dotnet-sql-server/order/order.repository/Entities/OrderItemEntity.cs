namespace order.repository.Entities;

[Table("OrderItem", Schema = "dbo")]
public class OrderItemEntity : BaseEntity
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    [ForeignKey(nameof(OrderId))]
    [InverseProperty(nameof(OrderEntity.Items))]
    public virtual OrderEntity Order { get; set; } = null!;

    [ForeignKey(nameof(ProductId))]
    [InverseProperty(nameof(ProductEntity.OrderItems))]
    public virtual ProductEntity Product { get; set; } = null!;
}