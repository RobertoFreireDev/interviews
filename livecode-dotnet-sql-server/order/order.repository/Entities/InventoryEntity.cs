namespace order.repository.Entities;

[Table("Inventory", Schema = "dbo")]
public class InventoryEntity : BaseEntity
{
    public int ProductId { get; set; }

    public int Availability { get; set; }

    [ForeignKey(nameof(ProductId))]
    [InverseProperty(nameof(ProductEntity.Inventories))]
    public virtual ProductEntity Product { get; set; } = null!;
}
