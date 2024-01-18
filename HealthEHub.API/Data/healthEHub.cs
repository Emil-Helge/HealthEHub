using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace HealthEHub.API.Data
{
    public class HealthEHubContext(DbContextOptions<HealthEHubContext> options) : IdentityDbContext(options)
    {
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
