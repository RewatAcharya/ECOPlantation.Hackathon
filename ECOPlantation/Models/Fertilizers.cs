using System.ComponentModel.DataAnnotations.Schema;

namespace ECOPlantation.Models
{
    public class Fertilizers : Base
    {
        public DateTime MsgDate { get; set; }
        public string PlantName { get; set; }
        public string FertilizerName { get; set; }
        [ForeignKey("UserFertilizer")]
        public int UserID {  get; set; }
        public virtual ApplicationUser? UserFertilizer {  get; set; }
        public DateTime? UpdatedDate { get; set; }


    }
}
