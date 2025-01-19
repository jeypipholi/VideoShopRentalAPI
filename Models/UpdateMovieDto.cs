namespace VideoShopRentalAPI.Models
{
    public class UpdateMovieDto
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public int RentalPrice { get; set; }
    }
}
