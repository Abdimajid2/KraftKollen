using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;
using System.Threading;

namespace KraftKollen.Helpers
{

    public class TrendCalculator : ITrendCalculator  // TrendCalculator implements the interface and is used to calculate the trend of wind power production
    {
        public string CalculateTrend(List<WindPowerProduction> data)
        {
            if (data.Count < 2)
            {
                return "Kan ej hitta trend.";   // If we have less than two data points we can't calculate a trend
            }

            
            var sortedData = data.OrderBy(d => d.Period).ToList(); // Sort data by year (Period), so we have the oldest data point first

            var firstValue = sortedData.First().Value;
            var lastValue = sortedData.Last().Value;


            if (lastValue > firstValue)
            {
                return "Trenden stiger!";
            }
            else if (lastValue < firstValue)
            {
                return "Trenden sjunker!";
            }
            else
            {
                return "Trenden orubbad!";
            }
        }
    }
}
