
namespace SharedModels.Models
{
    public class WorkoutPlan
    {
        public int WorkoutPlanId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public virtual ICollection<SavedExercise> Exercises { get; set; } = new List<SavedExercise>();
    }
}
