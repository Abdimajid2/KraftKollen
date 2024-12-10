using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;
using System.Threading;

namespace KraftKollen.Helpers
{

    public class TrendCalculator : ITrendCalculator // TrendCalculator implementerar Interfacet och används för att beräkna trenden för vindkraftsproduktionen
    {
        public string CalculateTrend(List<WindPowerProduction> data)
        {
            if (data.Count < 2)
            {
                return "Kan ej hitta trend.";  // Om vi inte har minst två datapunkter kan vi inte beräkna en trend
            }

            
            var sortedData = data.OrderBy(d => d.Period).ToList(); // Sortera data efter år (Period), så vi har den äldsta datapunkten först

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
