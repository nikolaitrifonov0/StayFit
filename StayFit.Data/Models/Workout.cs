﻿using Microsoft.AspNetCore.Identity;
using StayFit.Data.Models.Enums.Workout;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static StayFit.Data.DataConstants;

namespace StayFit.Data.Models
{
    public class Workout
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        [Required]
        [MaxLength(WorkoutNameMaxLength)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        [Required]
        public ICollection<WorkDay> WorkDays { get; set; } = new HashSet<WorkDay>();
        [Required]
        public WorkoutCycleType WorkoutCycleType { get; set; }
        public int? CycleDays { get; set; }
        public ICollection<ApplicationUser> Users { get; init; } = new HashSet<ApplicationUser>();
        public string ImageUrl { get; set; }
    }
}
