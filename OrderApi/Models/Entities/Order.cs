namespace OrderApi.Models.Entities
{
    public class Order : IEntity
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductOrder> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool NotificationSent { get; set; }
    }
}
