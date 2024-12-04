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
                return "Not enough data to calculate a trend.";
            }

            
            var sortedData = data.OrderBy(d => d.Period).ToList();

            var firstValue = sortedData.First().Value;
            var lastValue = sortedData.Last().Value;


            if (lastValue > firstValue)
            {
                return "Trend goes up.";
            }
            else if (lastValue < firstValue)
            {
                return "Trend goes down.";
            }
            else
            {
                return "Trend is unchanged.";
            }
        }
    }
}
