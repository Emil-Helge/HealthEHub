using SharedModels.Models;
namespace HealthEHub.API.Services
{
    public interface IMockDataService
    {
        IEnumerable<string> GetBodyParts();
        IEnumerable<string> GetAllEquipment();
        IEnumerable<string> GetTargetMuscles();
        IEnumerable<Exercise> GetExercises();
        Exercise GetExerciseById(int id);
    }
}
