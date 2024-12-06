namespace MyFItness.Models
{
    public class StrengthSet
    {
        public int Id { get; set; }
        public int StrengthActivityId { get; set; }
        public int Reps { get; set; }
        public double WeightLbs { get; set; }
        public string IntensityLevel { get; set; } // "Low", "Moderate", "High"

        public virtual StrengthActivity StrengthActivity { get; set; }
    }
}
