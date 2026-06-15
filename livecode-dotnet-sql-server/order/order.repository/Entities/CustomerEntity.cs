namespace order.repository.Entities;

[Table("Customer", Schema = "dbo")]
public class CustomerEntity : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    public virtual ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
}
