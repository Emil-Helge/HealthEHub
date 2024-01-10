using SharedModels.Models;
namespace HealthEHub.API.Services
{
    public interface IMockDataService
    {
        IEnumerable<string> GetBodyParts();
        IEnumerable<string> GetAllEquipment();
        IEnumerable<string> GetTargetMuscles();
        IEnumerable<Exercise> GetExercises(int offset, int limit);
        IEnumerable<Exercise> GetExercisesByBodyPart(string bodyPart, int limit, int offset);
        Exercise GetExerciseById(string id);
    }
}
