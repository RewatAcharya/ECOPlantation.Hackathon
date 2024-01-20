using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOPlantation.Models
{
    public class DonationRequest : Base
    {
        public string? RequestPhotoURL { get; set; }
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile? FileUpload { get; set; }

        public string? Content { get; set; }

        [ForeignKey("RequestedUser")]
        public int RequestedBy { get; set; }
        public virtual ApplicationUser? RequestedUser { get; set; }

        public bool Donated { get; set; } = false;
    }
}
