﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static StayFit.Data.DataConstants;
using WorkoutCycleTypeEnum = StayFit.Data.Models.Enums.Workout.WorkoutCycleType;

namespace StayFit.Web.Models.Workouts
{
    public class AddWorkoutFormModel
    {
        [Required]
        [StringLength(WorkoutNameMaxLength,
            MinimumLength = WorkoutNameMinLength,
            ErrorMessage = "The name should be between {2} and {1} symbols long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(WorkoutDescriptionMaxLength,
            MinimumLength = WorkoutDescriptionMinLength,
            ErrorMessage = "The description should be between {2} and {1} symbols long.")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Workout Type")]
        [EnumDataType(typeof(WorkoutCycleTypeEnum),
            ErrorMessage = "Workout Type should be one of the given values.")]
        public int WorkoutCycleType { get; set; }
        [Display(Name = "Cycle Days")]
        public int? CycleDays { get; set; }
        [Display(Name = "Thumbnail")]
        public string ImageUrl { get; set; }
        public IEnumerable<string> Exercises { get; init; }
    }
}
