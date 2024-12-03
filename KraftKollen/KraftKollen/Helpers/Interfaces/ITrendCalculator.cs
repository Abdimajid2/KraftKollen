using KraftKollen.Models;

namespace KraftKollen.Helpers.Interfaces
{
    public interface ITrendCalculator
    {
        string CalculateTrend(List<WindPowerProduction> data);
    }
}
