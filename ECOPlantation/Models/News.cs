using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOPlantation.Models
{
    public class News : Base
    {
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }

        public string? NewsPhotoURL { get; set; }
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile? FileUpload { get; set; }

        [ForeignKey("Poster")]
        public int PostedBy { get; set; }

        public virtual ApplicationUser? Poster { get; set; }
    }
}
