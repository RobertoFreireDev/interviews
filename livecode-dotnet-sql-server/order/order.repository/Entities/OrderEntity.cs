namespace order.repository.Entities;

[Table("Order", Schema = "dbo")]
public class OrderEntity : BaseEntity
{
    public int CustomerId { get; set; }

    public int TotalPrice { get; set; }

    [ForeignKey(nameof(CustomerId))]
    [InverseProperty(nameof(CustomerEntity.Orders))]
    public virtual CustomerEntity Customer { get; set; } = null!;

    [InverseProperty(nameof(OrderItemEntity.Order))]
    public virtual ICollection<OrderItemEntity> Items { get; set; } = new List<OrderItemEntity>();
}
