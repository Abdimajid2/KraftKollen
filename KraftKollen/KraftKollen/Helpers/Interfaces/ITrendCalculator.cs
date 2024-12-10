using KraftKollen.Models;

namespace KraftKollen.Helpers.Interfaces
{
    public interface ITrendCalculator  // Interface för att beräkna trend. 
    {
        string CalculateTrend(List<WindPowerProduction> data);
    }
}
