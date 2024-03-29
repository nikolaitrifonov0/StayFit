﻿namespace StayFit.Data
{
    public static class DataConstants
    {
        public const int UsernameMaxLength = 20;
        public const int PasswordMaxLength = 20;

        public const int ExerciseNameMaxLength = 20;
        public const int ExerciseNameMinLength = 3;
        public const int ExerciseDescriptionMaxLength = 2000;
        public const int ExerciseDescriptionMinLength = 10;

        public const int BodyPartNameMaxLength = 20;

        public const int EquipmentNameMaxLength = 20;        

        public const int WorkoutNameMaxLength = 20;
        public const int WorkoutNameMinLength = 3;
        public const int WorkoutDescriptionMaxLength = 2000;
        public const int WorkoutDescriptionMinLength = 10;

        public const int SetMaxLength = 10;

        public const int WeightMaxLenght = 3000;
        public const int WeightMinLenght = 0;

        public static readonly string[] DaysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    }
}
