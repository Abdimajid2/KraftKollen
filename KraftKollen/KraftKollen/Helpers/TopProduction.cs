using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;

namespace KraftKollen.Helpers
{
    public class TopProduction : ITopProduction
    {
        public List<(int Year, double Production)> GetTopProductionYears(List<WindPowerProduction> productionData, int topCount = 3)
        {
            var validData = productionData
                .Where(p => p.Period > 0 && p.Value.HasValue) // Filtrera bort ogiltiga värden
                .Select(p => (Year: p.Period ?? 0, Production: p.Value.Value)) // Mappa till tuple
                .ToList();

            // Kontrollera om vi har tillräcklig data
            if (validData.Count < topCount)
            {
                return new List<(int Year, double Production)>();
            }

            return validData
                .OrderByDescending(p => p.Production) // Sortera fallande
                .Take(topCount) // Hämta topp N år
                .ToList();
        }



    }
}
