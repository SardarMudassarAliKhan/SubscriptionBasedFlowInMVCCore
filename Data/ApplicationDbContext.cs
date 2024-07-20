using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubscriptionBasedFlowInMVCCore.Models;

namespace SubscriptionBasedFlowInMVCCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionFeature> SubscriptionFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubscriptionFeature>().HasData(
                new SubscriptionFeature { Id = 1, FeatureName = "Access to Basic Content", SubscriptionType = "Basic" },
                new SubscriptionFeature { Id = 2, FeatureName = "Access to Premium Content", SubscriptionType = "Premium" },
                new SubscriptionFeature { Id = 3, FeatureName = "Access to VIP Content", SubscriptionType = "VIP" },
                new SubscriptionFeature { Id = 4, FeatureName = "Priority Support", SubscriptionType = "VIP" }
            );
        }
    }
}
