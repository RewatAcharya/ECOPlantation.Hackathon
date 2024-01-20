using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOPlantation.Models
{
    public class ApplicationUser : Base
    {
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        [Phone]
        public string PhoneNo { get; set; }

        public required string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
