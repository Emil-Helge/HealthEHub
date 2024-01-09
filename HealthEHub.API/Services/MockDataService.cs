using SharedModels.Models;
using Bogus;

namespace HealthEHub.API.Services
{
    public class MockDataService : IMockDataService
    {
        private readonly List<Exercise> _mockExercises;

        public MockDataService()
        {
            _mockExercises = GenerateMockExercises(1300);
        }

        private List<Exercise> GenerateMockExercises(int count)
        {
            var exerciseId = 1;
            var testExercises = new Faker<Exercise>()
                .RuleFor(o => o.Id, f => (exerciseId++).ToString("D4"))
                .RuleFor(o => o.Name, f => f.PickRandom(new[] { "3/4 sit-up", "45° side bend", "squat", "alternate lateral pulldown", "ankle circles", "archer pull up", "archer push up", "cable lateral pulldown with v - bar", "cable low fly", "cable lying bicep curl", "cable lying close-grip curl", "dumbbell one arm zottman preacher curl", "dumbbell one leg fly on exercise ball" }))
                .RuleFor(o => o.BodyPart, f => f.PickRandom(new[] { "back", "cardio", "chest", "lower arms", "lower legs", "neck", "shoulders", "upper arms", "upper legs", "waist" }))
                .RuleFor(o => o.Equipment, f => f.PickRandom(new[] { "assisted", "band", "barbell", "body weight", "bosu ball", "cable", "dumbbell", "elliptical machine", "ez barbell", "hammer", "kettlebell", "leverage machine", "medicine ball", "olympic barbell", "resistance band", "roller", "rope", "skierg machine", "sled machine", "smith machine", "stability ball", "stationary bike", "stepmill machine", "tire", "trap bar", "upper body ergometer", "weighted", "wheel roller" }))
                .RuleFor(o => o.GifUrl, "https://v2.exercisedb.io/image/wz7ldAbgjiwCDI")
                .RuleFor(o => o.Target, f => f.PickRandom(new[] { "abductors", "abs", "adductors", "biceps", "calves", "cardiovascular system", "delts", "forearms", "glutes", "hamstrings", "lats", "levator scapulae", "pectorals", "quads", "serratus anterior", "spine", "traps", "triceps", "upper back" }))
                .RuleFor(o => o.SecondaryMuscles, f => new[] { f.PickRandom(new[] { "hip flexors", "lower back", "obliques" }) })
                .RuleFor(o => o.Instructions, f => new[]
                {
            "Lie flat on your back with your knees bent and feet flat on the ground.",
            "Place your hands behind your head with your elbows pointing outwards.",
            "Engaging your abs, slowly lift your upper body off the ground, curling forward until your torso is at a 45-degree angle.",
            "Pause for a moment at the top, then slowly lower your upper body back down to the starting position.",
            "Repeat for the desired number of repetitions."
                });

            return testExercises.Generate(count);
        }

        public IEnumerable<string> GetBodyParts()
        {
            return new List<string>
            {
                "back",
                "cardio",
                "chest",
                "lower arms",
                "lower legs",
                "neck",
                "shoulders",
                "upper arms",
                "upper legs",
                "waist",
            };
        }
        public IEnumerable<string> GetAllEquipment()
        {
            return new List<string>
            {
                "assisted",
                "band",
                "barbell",
                "body weight",
                "bosu ball",
                "cable",
                "dumbbell",
                "elliptical machine",
                "ez barbell",
                "hammer",
                "kettlebell",
                "leverage machine",
                "medicine ball",
                "olympic barbell",
                "resistance band",
                "roller",
                "rope",
                "skierg machine",
                "sled machine",
                "smith machine",
                "stability ball",
                "stationary bike",
                "stepmill machine",
                "tire",
                "trap bar",
                "upper body ergometer",
                "weighted",
                "wheel roller"
            };
        }
        public IEnumerable<string> GetTargetMuscles()
        {
            return new List<string>
            {
                "abductors",
                "abs",
                "adductors",
                "biceps",
                "calves",
                "cardiovascular system",
                "delts",
                "forearms",
                "glutes",
                "hamstrings",
                "lats",
                "levator scapulae",
                "pectorals",
                "quads",
                "serratus anterior",
                "spine",
                "traps",
                "triceps",
                "upper back"
            };
        }
        public IEnumerable<Exercise> GetExercises(int offset, int limit)
        {
            return _mockExercises.Skip(offset).Take(limit);
        }

        public Exercise GetExerciseById(string id)
        {
            var exercise = _mockExercises.FirstOrDefault(e => e.Id == id);
            if (exercise == null)
            {
                throw new KeyNotFoundException($"Exercise with ID {id} was not found.");
            }
            return exercise;
        }


    }
}