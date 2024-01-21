using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace HealthEHub.API.Data
{
    public class HealthEHubContext(DbContextOptions<HealthEHubContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<SavedExercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WorkoutPlan>()
                .HasMany(wp => wp.Exercises)
                .WithOne(e => e.WorkoutPlan)
                .HasForeignKey(e => e.WorkoutPlanId)
                .IsRequired(false);
        }
    }

}
