namespace OrderApi.Models
{
    public class ProductOrder
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
