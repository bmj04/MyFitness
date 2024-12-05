using System;
using System.Collections.Generic;

namespace MyFItness.Models
{
    public class StrengthActivity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public string ExerciseType { get; set; } // "Bench Press", "Squats", or "Deadlifts"
        public string Notes { get; set; }

        // Navigation Properties
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<StrengthSet> Sets { get; set; }
    }
}
