using System.ComponentModel.DataAnnotations.Schema;

namespace ECOPlantation.Models
{
    public class Visitor : Base
    {
        [ForeignKey("VisitorFK")]
        public int VistorID { get; set; }
        public virtual ApplicationUser? VisitorFK { get; set; }
        
        [ForeignKey("InvitedBy")]
        public int InviteID { get; set; }
        public virtual Invite? InvitedBy { get; set; }
    }
}
