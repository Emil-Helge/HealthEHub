namespace SharedModels.Models
{
    public class SavedExercise
    {
        public string InstanceId { get; set; } = string.Empty;
        public int SavedExerciseId { get; set; }
        public string ExerciseId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int WorkoutPlanId { get; set; }
        public string? DayOfWeek { get; set; }
        public int? WeekNumber { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
    }
}
