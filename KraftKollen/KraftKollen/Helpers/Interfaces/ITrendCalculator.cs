using KraftKollen.Models;

namespace KraftKollen.Helpers.Interfaces
{
    public interface ITrendCalculator  // Interface to calculate trend.
    {
        string CalculateTrend(List<WindPowerProduction> data);
    }
}
