namespace SharedModels.Models
{
    public class WorkoutPlan
    {
        public int WorkoutPlanId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Exercise> Exercises { get; set; } = [];
        public int UserId { get; set; }
        public User User { get; set; } = new User();
    }

}
