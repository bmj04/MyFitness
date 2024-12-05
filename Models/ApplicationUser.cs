using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MyFItness.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Personal Information
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public double? HeightCm { get; set; }
        public double? WeightLbs { get; set; }
        public double? BodyFatPercentage { get; set; }
        public string? Gender { get; set; }
        public string? FitnessGoal { get; set; }
        public bool IsTrainer { get; set; }

        // Navigation Properties
        public virtual ICollection<StrengthActivity> StrengthActivities { get; set; }
        public virtual ICollection<CardioActivity> CardioActivities { get; set; }
        public virtual ICollection<NutritionEntry> NutritionEntries { get; set; }
    }
}
