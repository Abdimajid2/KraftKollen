using KraftKollen.Models;

namespace KraftKollen.Helpers.Interfaces
{
    public interface ITopProduction  // Interface för att analysera produktionstoppar.
    {
        List<(int Year, double Production)> GetTopProductionYears(List<WindPowerProduction> productionData, int topCount = 3);
    }
}
