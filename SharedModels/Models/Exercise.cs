namespace SharedModels.Models
{
    public class Exercise
    {
        public string BodyPart { get; set; } = string.Empty;
        public string Equipment { get; set; } = string.Empty;
        public string GifUrl { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public string[] SecondaryMuscles { get; set; } = [];
        public string[] Instructions { get; set; } = [];
    }
}
