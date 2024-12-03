using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;

namespace KraftKollen.Helpers
{

    public class TrendCalculator : ITrendCalculator
    {
        public string CalculateTrend(List<WindPowerProduction> data)
        {
            if (data.Count < 2)
            {
                return "Inte tillräckligt med data för att beräkna en trend.";
            }

            
            var sortedData = data.OrderBy(d => d.Period).ToList();

            var firstValue = sortedData.First().Value;
            var lastValue = sortedData.Last().Value;


            if (lastValue > firstValue)
            {
                return "Trenden går uppåt.";
            }
            else if (lastValue < firstValue)
            {
                return "Trenden går nedåt.";
            }
            else
            {
                return "Trenden är oförändrad.";
            }
        }
    }
}
