namespace SharedModels.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string GoogleId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<WorkoutPlan> WorkoutPlans { get; set; } = [];
    }

}
