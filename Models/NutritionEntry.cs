using System;

namespace MyFItness.Models
{
    public class NutritionEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int TotalCalories { get; set; }
        public double ProteinGrams { get; set; }
        public double CarbsGrams { get; set; }
        public double FatsGrams { get; set; }
        public string Notes { get; set; }

        // Navigation Property
        public virtual ApplicationUser User { get; set; }
    }
}
