namespace VideoShopRentalAPI.Models
{
    public class AddCustomerDto
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
    }
}
