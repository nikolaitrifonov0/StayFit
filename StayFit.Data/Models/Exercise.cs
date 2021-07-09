﻿using StayFit.Data.Models.Enums.Exercise;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static StayFit.Data.DataConstants;

namespace StayFit.Data.Models
{
    public class Exercise
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(ExerciseNameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Equipment Equipment { get; set; }
        [Required]
        public ICollection<BodyPart> BodyParts { get; init; } = new HashSet<BodyPart>();        
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public ICollection<WorkDay> WorkDays { get; init; } = new HashSet<WorkDay>();
        public ICollection<UserExerciseLog> UserExerciseLogs { get; init; }
            = new HashSet<UserExerciseLog>();
    }
}
