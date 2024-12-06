using System;

namespace MyFItness.Models
{
    public class CardioActivity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string ActivityType { get; set; } // "Running", "Cycling", or "Swimming"
        public int DurationMinutes { get; set; }
        public double DistanceKm { get; set; }
        public string IntensityLevel { get; set; } // "Low", "Moderate", "High"
        public string Notes { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
