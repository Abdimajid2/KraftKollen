using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;
using System.Threading;

namespace KraftKollen.Helpers
{

    public class TrendCalculator : ITrendCalculator
    {
        public string CalculateTrend(List<WindPowerProduction> data)
        {
            if (data.Count < 2)
            {
                return "Kan ej hitta trend.";
            }

            
            var sortedData = data.OrderBy(d => d.Period).ToList();

            var firstValue = sortedData.First().Value;
            var lastValue = sortedData.Last().Value;


            if (lastValue > firstValue)
            {
                return "Trendens stiger!";
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
