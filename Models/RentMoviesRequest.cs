namespace VideoShopRentalAPI.Models
{
    public class RentMoviesRequest
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
        public int RentalDuration { get; set; }
    }
}
