using ECOPlantation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECOPlantation.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PlantCount> PlantCounts { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<DonationPayment> DonationPayments { get; set; }
        public DbSet<News> News { get; set; }
    }
}
