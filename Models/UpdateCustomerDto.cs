namespace VideoShopRentalAPI.Models
{
    public class UpdateCustomerDto
    {
        public int CustomerId { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
    }
}
