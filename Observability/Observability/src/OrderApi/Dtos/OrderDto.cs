namespace OrderApi.Dtos
{
    public class OrderDto
    {
        public ProductDto Product { get; set; }

        public Guid OrderId { get; set; }
    }
}