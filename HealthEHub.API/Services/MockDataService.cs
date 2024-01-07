using SharedModels.Models;

namespace HealthEHub.API.Services
{
    public class MockDataService : IMockDataService
    {
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
        public IEnumerable<Exercise> GetExercises()
        {
            return new List<Exercise>
            {
                new()
                {
                    BodyPart = "waist",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/FNFaI8kmnQ-1BO",
                    Id =  "0001",
                    Name = "3/4 sit-up",
                    Target = "abs",
                    SecondaryMuscles =
                    [
                        "hip flexors",
                        "lower back"
                    ],
                    Instructions =
                    [
                        "Lie flat on your back with your knees bent and feet flat on the ground.",
                        "Place your hands behind your head with your elbows pointing outwards.",
                        "Engaging your abs, slowly lift your upper body off the ground, curling forward until your torso is at a 45-degree angle.",
                        "Pause for a moment at the top, then slowly lower your upper body back down to the starting position.",
                        "Repeat for the desired number of repetitions."
                    ]
                },
                new()
                {
                    BodyPart = "waist",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/G0CSVtDq67Y2Zq",
                    Id =  "0002",
                    Name = "45° side bend",
                    Target = "abs",
                    SecondaryMuscles =
                    [
                        "obliques"
                    ],
                    Instructions =
                    [
                        "Stand with your feet shoulder-width apart and your arms extended straight down by your sides.",
                        "Keeping your back straight and your core engaged, slowly bend your torso to one side, lowering your hand towards your knee.",
                        "Pause for a moment at the bottom, then slowly return to the starting position.",
                        "Repeat on the other side.",
                        "Continue alternating sides for the desired number of repetitions."
                    ]
                },
                new()
                {
                    BodyPart = "waist",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/PHX2GFTslQzKiX",
                    Id =  "0003",
                    Name = "air bike",
                    Target = "abs",
                    SecondaryMuscles =
                    [
                        "hip flexors"
                    ],
                    Instructions =
                    [
                        "Lie flat on your back with your hands placed behind your head.",
                        "Lift your legs off the ground and bend your knees at a 90-degree angle.",
                        "Bring your right elbow towards your left knee while simultaneously straightening your right leg.",
                        "Return to the starting position and repeat the movement on the opposite side, bringing your left elbow towards your right knee while straightening your left leg.",
                        "Continue alternating sides in a pedaling motion for the desired number of repetitions."
                    ]
                },
                new()
                {
                    BodyPart = "upper legs",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/7Sk8bfK9dWeEAi",
                    Id =  "1512",
                    Name = "all fours squad stretch",
                    Target = "quads",
                    SecondaryMuscles =
                    [
                        "hamstrings",
                        "glutes"
                    ],
                    Instructions =
                    [
                        "Start on all fours with your hands directly under your shoulders and your knees directly under your hips.",
                        "Extend one leg straight back, keeping your knee bent and your foot flexed.",
                        "Slowly lower your hips towards the ground, feeling a stretch in your quads.",
                        "Hold this position for 20-30 seconds.",
                        "Switch legs and repeat the stretch on the other side."
                    ]
                },
                new()
                {
                    BodyPart = "waist",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/TbmLyfYuVL9j1m",
                    Id =  "0006",
                    Name = "alternate heel touchers",
                    Target = "abs",
                    SecondaryMuscles =
                    [
                        "obliques"
                    ],
                    Instructions =
                    [
                        "Lie flat on your back with your knees bent and feet flat on the ground.",
                        "Extend your arms straight out to the sides, parallel to the ground.",
                        "Engaging your abs, lift your shoulders off the ground and reach your right hand towards your right heel.",
                        "Return to the starting position and repeat on the left side, reaching your left hand towards your left heel.",
                        "Continue alternating sides for the desired number of repetitions."
                    ]
                },
                new()
                {
                    BodyPart = "back",
                    Equipment = "cable",
                    GifUrl = "https://v2.exercisedb.io/image/sismJhlZOgUuWL",
                    Id =  "0007",
                    Name = "alternate lateral pulldown",
                    Target = "lats",
                    SecondaryMuscles =
                    [
                        "biceps",
                        "rhomboids"
                    ],
                    Instructions =
                    [
                        "Sit on the cable machine with your back straight and feet flat on the ground.",
                        "Grasp the handles with an overhand grip, slightly wider than shoulder-width apart.",
                        "Lean back slightly and pull the handles towards your chest, squeezing your shoulder blades together.",
                        "Pause for a moment at the peak of the movement, then slowly release the handles back to the starting position.",
                        "Repeat for the desired number of repetitions."
                    ]
                },
                new()
                {
                    BodyPart = "lower legs",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/d3x1Kgc-H4Blg0",
                    Id =  "1368",
                    Name = "ankle circles",
                    Target = "calves",
                    SecondaryMuscles =
                    [
                        "ankle stabilizers"
                    ],
                    Instructions =
                    [
                        "Sit on the ground with your legs extended in front of you.",
                        "Lift one leg off the ground and rotate your ankle in a circular motion.",
                        "Perform the desired number of circles in one direction, then switch to the other direction.",
                        "Repeat with the other leg."
                    ]
                },
                new()
                {
                    BodyPart = "back",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/M4LIybSgfv-YEt",
                    Id =  "3293",
                    Name = "archer pull up",
                    Target = "lats",
                    SecondaryMuscles =
                    [
                        "biceps",
                        "forearms"
                    ],
                    Instructions =
                    [
                        "Start by hanging from a pull-up bar with an overhand grip, slightly wider than shoulder-width apart.",
                        "Engage your core and pull your shoulder blades down and back.",
                        "As you pull yourself up, bend one arm and bring your elbow towards your side, while keeping the other arm straight.",
                        "Continue pulling until your chin is above the bar and your bent arm is fully flexed.",
                        "Lower yourself back down with control, straightening the bent arm and repeating the movement on the other side.",
                        "Alternate sides with each repetition."
                    ]
                },
                new()
                {
                    BodyPart = "chest",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/c-IYLVp13j8F9o",
                    Id =  "3294",
                    Name = "archer push up",
                    Target = "pectorals",
                    SecondaryMuscles =
                    [
                        "triceps",
                        "shoulders",
                        "core"
                    ],
                    Instructions =
                    [
                        "Start in a push-up position with your hands slightly wider than shoulder-width apart.",
                        "Extend one arm straight out to the side, parallel to the ground.",
                        "Lower your body by bending your elbows, keeping your back straight and core engaged.",
                        "Push back up to the starting position.",
                        "Repeat on the other side, extending the opposite arm out to the side.",
                        "Continue alternating sides for the desired number of repetitions."
                    ]
                },
                new()
                {
                    BodyPart = "waist",
                    Equipment = "body weight",
                    GifUrl = "https://v2.exercisedb.io/image/zAZFUsnoIgcuk4",
                    Id =  "2355",
                    Name = "arm slingers hanging bent knee legs",
                    Target = "abs",
                    SecondaryMuscles =
                    [
                        "shoulders",
                        "back"
                    ],
                    Instructions =
                    [
                        "Hang from a pull-up bar with your arms fully extended and your knees bent at a 90-degree angle.",
                        "Engage your core and lift your knees towards your chest, bringing them as close to your elbows as possible.",
                        "Slowly lower your legs back down to the starting position.",
                        "Repeat for the desired number of repetitions."
                    ]
                },
            };
        }
        public Exercise GetExerciseById(int id)
        {
            var exercises = GetExercises();
            var exercise = exercises.FirstOrDefault(e => e.Id == id.ToString()) ?? throw new InvalidOperationException("Exercise not found.");
            return exercise;
        }
    }
}