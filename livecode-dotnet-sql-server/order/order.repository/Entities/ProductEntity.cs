namespace order.repository.Entities;

[Table("Product", Schema = "dbo")]
public class ProductEntity : BaseEntity
{
    [Required]
    [StringLength(15)]
    public string Sku { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<InventoryEntity> Inventories { get; set; } = new List<InventoryEntity>();
    public virtual ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
}
