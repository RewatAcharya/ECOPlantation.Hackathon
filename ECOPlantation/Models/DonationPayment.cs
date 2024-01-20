using System.ComponentModel.DataAnnotations.Schema;

namespace ECOPlantation.Models
{
    public class DonationPayment : Base
    {
        [ForeignKey("UserId")]
        public int DonatedBy { get; set; }
        public virtual ApplicationUser? DonatedUser { get; set; }
        
        [ForeignKey("DonationId")]
        public int RequestedDonation { get; set; }
        public virtual DonationRequest? DonationId { get; set; }

        public double TotalDonation { get; set; }
    }
}
