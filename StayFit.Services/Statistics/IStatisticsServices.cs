﻿namespace StayFit.Services.Statistics
{
    public interface IStatisticsServices
    {
        public StatisticsServiceModel GetAll(string userId);
    }
}
