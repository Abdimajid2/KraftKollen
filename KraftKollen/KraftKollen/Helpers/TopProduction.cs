using KraftKollen.Helpers.Interfaces;
using KraftKollen.Models;

namespace KraftKollen.Helpers
{
    public class TopProduction : ITopProduction  // Klass som hämtar interface för att analysera produktionstoppar.
    {
        public List<(int Year, double Production)> GetTopProductionYears(List<WindPowerProduction> productionData, int topCount = 3)
        {
            var validData = productionData
                .Where(p => p.Period > 0 && p.Value.HasValue) // Filtrera bort ogiltiga värden som tex noll eller negativa tal. 
                .Select(p => (Year: p.Period ?? 0, Production: p.Value.Value)) // Mappa till tuple och skapa en lista med år och produktion. 
                .ToList();

            // Kontrollera om vi har tillräcklig data, har vi inte det så retrunera en tom lista.
            if (validData.Count < topCount)
            {
                return new List<(int Year, double Production)>();
            }

            return validData
                .OrderByDescending(p => p.Production) // Sortera i fallande ordning efter produktion
                .Take(topCount) // Ta de tre första (bästa) åren och returnera som en lista
                .ToList();
        }



    }
}
