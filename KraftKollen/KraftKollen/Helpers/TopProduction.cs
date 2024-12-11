using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;

namespace KraftKollen.Helpers
{
    public class TopProduction : ITopProduction  // Class to analyze production peaks.
    {
        public List<(int Year, double Production)> GetTopProductionYears(List<WindPowerProduction> productionData, int topCount = 3)
        {
            var validData = productionData
                .Where(p => p.Period > 0 && p.Value.HasValue) // Filter out invalid values such as zero or negative numbers.
                .Select(p => (Year: p.Period ?? 0, Production: p.Value.Value))  // Map to tuple and create a list with year and production.
                .ToList();

             // Check if we have enough data, if not return an empty list.
            if (validData.Count < topCount)
            {
                return new List<(int Year, double Production)>();
            }

            return validData
                .OrderByDescending(p => p.Production)  // Sort in descending order by production
                .Take(topCount)  // Take the first three (best) years and return as a list
                .ToList();
        }



    }
}
