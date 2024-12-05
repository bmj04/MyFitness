using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFItness.Models;

namespace MyFItness.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<StrengthActivity> StrengthActivities { get; set; }
        public DbSet<StrengthSet> StrengthSets { get; set; }
        public DbSet<CardioActivity> CardioActivities { get; set; }
        public DbSet<NutritionEntry> NutritionEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            modelBuilder.Entity<StrengthActivity>()
                .HasOne(sa => sa.User)
                .WithMany(u => u.StrengthActivities)
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CardioActivity>()
                .HasOne(ca => ca.User)
                .WithMany(u => u.CardioActivities)
                .HasForeignKey(ca => ca.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NutritionEntry>()
                .HasOne(ne => ne.User)
                .WithMany(u => u.NutritionEntries)
                .HasForeignKey(ne => ne.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StrengthSet>()
                .HasOne(ss => ss.StrengthActivity)
                .WithMany(sa => sa.Sets)
                .HasForeignKey(ss => ss.StrengthActivityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
