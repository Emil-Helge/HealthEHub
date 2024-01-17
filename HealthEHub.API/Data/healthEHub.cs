using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace HealthEHub.API.Data
{
    public class HealthEHubContext(DbContextOptions<HealthEHubContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
    }
}
