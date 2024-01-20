using System.ComponentModel.DataAnnotations.Schema;

namespace ECOPlantation.Models
{
    public class Invite : Base
    {

        public string EventName { get; set; }
        public string Status { get; set; }  
        public string Location { get; set; }
        public string Content { get; set; }
        [ForeignKey("OrganiserFK")]
        public int Organiser { get; set; }
        public virtual ApplicationUser? OrganiserFK { get; set; }
        public DateTime EventDate { get; set; }
    }
}
