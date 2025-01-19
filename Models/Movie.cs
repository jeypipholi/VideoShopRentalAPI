using System.Security.Principal;

namespace VideoShopRentalAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public required string Title { get; set; }
        public int  RentalPrice { get; set; }

    }
}
