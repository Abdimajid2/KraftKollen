﻿using KraftKollen.Models;

namespace KraftKollen.Helpers.Interfaces
{
    public interface ITopProduction  // Interface to analyze production peaks.
    {
        List<(int Year, double Production)> GetTopProductionYears(List<WindPowerProduction> productionData, int topCount = 3);
    }
}
