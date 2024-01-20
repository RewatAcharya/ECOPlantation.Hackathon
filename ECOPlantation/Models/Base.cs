using System.ComponentModel.DataAnnotations;

namespace ECOPlantation.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    } 
}