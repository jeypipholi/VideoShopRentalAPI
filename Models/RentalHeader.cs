using Microsoft.AspNetCore.Routing.Template;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoShopRentalAPI.Models
{
    public class RentalHeader
    {
        [Key]
        public int RentalId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public int RentalDuration { get; set; }
    }
}
