using OrderApi.Models;

namespace OrderApi.DTOs
{
    public class AddOrderDto
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<ProductOrder> Products { get; set; }
    }
}
