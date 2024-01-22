namespace SharedModels.Models
{
    public class SavedExercise
    {
        public int SavedExerciseId { get; set; }
        public string ExerciseId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int WorkoutPlanId { get; set; }
        public virtual WorkoutPlan WorkoutPlan { get; set; }
    }
}
