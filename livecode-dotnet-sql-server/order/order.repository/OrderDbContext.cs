namespace order.repository;

public class OrderDbContext : DbContext
{
    public DbSet<CustomerEntity> Customers { get; set; }

    public DbSet<InventoryEntity> Inventories { get; set; }

    public DbSet<OrderEntity> Orders { get; set; }

    public DbSet<OrderItemEntity> OrderItems { get; set; }

    public DbSet<ProductEntity> Products { get; set; }

    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CustomerEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<ProductEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<InventoryEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<OrderEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<OrderItemEntity>().Property(e => e.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<CustomerEntity>().ToTable("Customer", "dbo");
        modelBuilder.Entity<ProductEntity>().ToTable("Product", "dbo");
        modelBuilder.Entity<InventoryEntity>().ToTable("Inventory", "dbo");
        modelBuilder.Entity<OrderEntity>().ToTable("Order", "dbo");
        modelBuilder.Entity<OrderItemEntity>().ToTable("OrderItem", "dbo");
    }
}